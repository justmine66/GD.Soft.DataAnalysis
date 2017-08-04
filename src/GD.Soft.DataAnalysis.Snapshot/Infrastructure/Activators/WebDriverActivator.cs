using GD.Soft.DataAnalysis.Snapshot.Entities;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services.Abstractions;
using GD.Soft.DataAnalysis.Snapshot.ValueObjects;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Activators
{
    /// <summary>
    /// 浏览器催化器
    /// </summary>
    public class WebDriverActivator
    {
        /// <summary>
        /// 根据页面行为，初始化浏览器实例
        /// </summary>
        /// <param name="actions">页面行为</param>
        /// <returns>浏览器</returns>
        public virtual BrowserEntity ActivatorWebDriver(PageActions actions)
        {
            IBrowserService bs = new DefaultBrowserService();
            RemoteWebDriver Browser= bs.GetBrowser(actions.BrowserOptions);
            var result = new BrowserEntity(Browser, actions);
            return result;
        }
    }
}
