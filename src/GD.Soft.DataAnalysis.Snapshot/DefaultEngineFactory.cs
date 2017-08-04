using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GD.Soft.DataAnalysis.Snapshot.Entities;
using OpenQA.Selenium.Remote;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Activators;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services.Abstractions;

namespace GD.Soft.DataAnalysis.Snapshot
{
    /// <summary>
    /// 默认引擎工厂
    /// </summary>
    public class DefaultEngineFactory : IEngineFactory
    {
        /// <summary>
        /// 获取页面行为催化器
        /// </summary>
        /// <returns>页面行为催化器</returns>
        public virtual PageActionActivator GetPageActionActivator()
        {
            return new PageActionActivator();
        }

        /// <summary>
        /// 获取浏览器催化器
        /// </summary>
        /// <returns>浏览器催化器</returns>
        public virtual WebDriverActivator GetWebDriverActivator()
        {
            return new WebDriverActivator();
        }

        /// <summary>
        /// 获取屏幕快照催化器
        /// </summary>
        /// <returns>屏幕快照催化器</returns>
        public virtual ScreenshotActivator GetScreenshotActivator()
        {
            return new ScreenshotActivator();
        }

        /// <summary>
        /// 获取结果参数催化器
        /// </summary>
        /// <returns>结果参数催化器</returns>
        public ResultArgsActivator GetResultArgsActivator()
        {
            return new ResultArgsActivator();
        }
    }
}
