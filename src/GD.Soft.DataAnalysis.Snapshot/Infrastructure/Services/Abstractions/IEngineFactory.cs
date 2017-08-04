using GD.Soft.DataAnalysis.Snapshot.Entities;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Activators;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services.Abstractions
{
    /// <summary>
    /// 引擎工厂
    /// 说明：为引擎提供各种对象
    /// </summary>
    public interface IEngineFactory
    {
        /// <summary>
        /// 获取页面操作催化器
        /// </summary>
        /// <returns></returns>
        PageActionActivator GetPageActionActivator();

        /// <summary>
        /// 获取浏览器催化器
        /// </summary>
        /// <returns></returns>
        WebDriverActivator GetWebDriverActivator();

        /// <summary>
        /// 获取屏幕快照催化器
        /// </summary>
        /// <returns></returns>
        ScreenshotActivator GetScreenshotActivator();

        /// <summary>
        /// 获取结果参数催化器
        /// </summary>
        /// <returns></returns>
        ResultArgsActivator GetResultArgsActivator();

    }
}
