using GD.Soft.DataAnalysis.Snapshot.Entities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.IntegrationEvents.Events
{
    /// <summary>
    /// 完成事件
    /// </summary>
    public class OnCompletedIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// 线程标识
        /// </summary>
        public int TheadId { get; private set; }

        /// <summary>
        /// 结果参数
        /// </summary>
        public ResultArgs ResultArgs { get; private set; }

        /// <summary>
        /// 耗时
        /// </summary>
        public TimeSpan Elapsed { get; private set; }

        /// <summary>
        /// 初始化完成事件实例
        /// </summary>
        /// <param name="theadId">线程标识</param>
        /// <param name="uri">地址</param>
        /// <param name="resultshot">结果快照</param>
        /// <param name="elapsed">耗时</param>
        public OnCompletedIntegrationEvent(int theadId, ResultArgs resultArgs, TimeSpan elapsed)
        {
            this.TheadId = theadId;
            this.ResultArgs = resultArgs;
            this.Elapsed = elapsed;
        }
    }
}
