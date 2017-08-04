using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GD.Soft.DataAnalysis.Snapshot.ValueObjects;
using OpenQA.Selenium.Remote;
using GD.Soft.DataAnalysis.Snapshot.Entities.Browsers;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services
{
    /// <summary>
    /// 默认浏览器服务
    /// </summary>
    public class DefaultBrowserService : IBrowserService
    {
        /// <summary>
        /// 获取浏览器
        /// </summary>
        /// <param name="options">浏览器选项</param>
        /// <returns>浏览器</returns>
        public RemoteWebDriver GetBrowser(Enum_BrowserOptions options)
        {
            RemoteWebDriver Browser;
            switch (options)
            {
                case Enum_BrowserOptions.None:
                case Enum_BrowserOptions.PhantomJS:
                default:
                    Browser = PhantomJS.New;
                    break;
                case Enum_BrowserOptions.IE:
                    Browser = IE.New;
                    break;
            }
            return Browser;
        }
    }
}
