using GD.Soft.DataAnalysis.Snapshot.ValueObjects;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services.Abstractions
{
    /// <summary>
    /// 浏览器服务
    /// </summary>
    public interface IBrowserService
    {
        RemoteWebDriver GetBrowser(Enum_BrowserOptions options);
    }
}
