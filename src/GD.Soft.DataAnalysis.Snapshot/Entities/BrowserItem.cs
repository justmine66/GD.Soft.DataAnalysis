using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Entities
{
    /// <summary>
    /// 浏览器实体
    /// </summary>
    public class BrowserEntity
    {
        public RemoteWebDriver Browser { get; private set; }
        public PageActions PageActions { get; private set; }

        public BrowserEntity(RemoteWebDriver browser, PageActions actions)
        {
            this.Browser = browser;
            this.PageActions = actions;
        }
    }
}
