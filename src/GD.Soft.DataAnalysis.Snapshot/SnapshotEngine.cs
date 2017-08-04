using GD.Soft.DataAnalysis.Snapshot.Entities;
using GD.Soft.DataAnalysis.Snapshot.Entities.Browsers;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Common;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Exceptions;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services.Abstractions;
using GD.Soft.DataAnalysis.Snapshot.IntegrationEvents.Events;
using GD.Soft.DataAnalysis.Snapshot.ValueObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot
{
    /// <summary>
    /// 快照引擎
    /// </summary>
    public class SnapshotEngine
    {
        #region 事件，应用场景：进度监控、异常捕获。

        /// <summary>
        /// 开始事件
        /// </summary>
        public virtual event EventHandler<OnStartupIntegrationEvent> OnStarted;

        /// <summary>
        /// 完成事件
        /// </summary>
        public virtual event EventHandler<OnCompletedIntegrationEvent> OnCompleted;

        /// <summary>
        /// 异常事件
        /// </summary>
        public virtual event EventHandler<OnErroredIntegrationEvent> OnErrored;

        #endregion

        /// <summary>
        /// 自动重试次数
        /// </summary>
        public int ReTryCount { get; private set; }
        public void SetReTryCount(int reTryCount)
        {
            if (reTryCount < 0) this.ReTryCount = 5;//默认
            else this.ReTryCount = reTryCount;
        }

        /// <summary>
        /// 引擎工厂
        /// 说明：若需定制化流程控制，重新该工厂即可。
        /// </summary>
        public IEngineFactory Factory { get; private set; }

        /// <summary>
        /// 初始化一个快照引擎实例
        /// </summary>
        /// <param name="factory"></param>
        public SnapshotEngine(IEngineFactory factory = null)
        {
            this.Factory = factory ?? new DefaultEngineFactory();
        }

        /// <summary>
        /// 启动引擎
        /// </summary>
        /// <param name="filter"></param>
        public void Start(FilterItem filter)
        {
            Func<ResultArgs> action = () =>
            {
                PageActions pacs = Factory.GetPageActionActivator().ActivatePageActions(filter);
                BrowserEntity browser = Factory.GetWebDriverActivator().ActivatorWebDriver(pacs);
                Screenshot snapshot = Factory.GetScreenshotActivator().ActivatorScreenshot(browser);
                ResultArgs result = Factory.GetResultArgsActivator().ActivatorResultArgs(snapshot);
                return result;
            };
            ResiliencePolicy.New
                .ReTry(() => { this.DoStart(filter, action); }, this.ReTryCount);
        }

        private void DoStart(FilterItem filter, Func<ResultArgs> action)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                if (null != this.OnStarted) this.OnStarted(this, new OnStartupIntegrationEvent(new Uri(filter.Url)));
                ResultArgs result = action();
                watch.Stop();
                if (null != this.OnCompleted)
                {
                    int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                    this.OnCompleted(this, new OnCompletedIntegrationEvent(threadId, result, watch.Elapsed));
                }
            }
            catch (Exception ex)
            {
                this.DoExption(filter, action, ex);
            }
        }

        private void DoExption(FilterItem filter, Func<ResultArgs> action, Exception ex)
        {
            if (null != this.OnErrored)
            {
                SnapshotBuildException snapshot_exption;
                if (ex is SnapshotBuildException)
                    snapshot_exption = ex as SnapshotBuildException;
                else
                    snapshot_exption = new SnapshotBuildException(ex.Message, ex);
                this.OnErrored(this,
                        new OnErroredIntegrationEvent(new Uri(filter.Url),
                        snapshot_exption));
                if (ResiliencePolicy.NumOfTime < this.ReTryCount)
                {
                    throw snapshot_exption;
                }
                else
                {
                    //this.DoRestFinalize(filter.Browser);
                }
            }
        }

        /// <summary>
        /// 进程终接器，清理遗留进程。
        /// </summary>
        /// <param name="Browser">浏览器</param>
        private void DoRestFinalize(Enum_BrowserOptions Browser)
        {
            switch (Browser)
            {
                case Enum_BrowserOptions.None:
                case Enum_BrowserOptions.PhantomJS:
                default:
                    PhantomJS.DoRestFinalize();
                    break;
                case Enum_BrowserOptions.IE:
                    IE.DoRestFinalize();
                    break;
            }
        }
    }
}
