using GD.Soft.DataAnalysis.Snapshot.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace GD.Soft.DataAnalysis.Snapshot.Entities.Browsers
{
    /// <summary>
    /// 摘要：
    ///     PhantomJS无头浏览器
    /// </summary>
    public class PhantomJS
    {
        private static readonly string driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Components/phantomjs");

        #region 单子实例

        private static readonly Lazy<PhantomJSDriver> _webDriver = new Lazy<PhantomJSDriver>(() =>
        {
            return new PhantomJSDriver(driverPath);
        });
        public static PhantomJSDriver Singleton { get { return _webDriver.Value; } }

        #endregion

        public static PhantomJSDriver New { get { return new PhantomJSDriver(driverPath); } }

        /// <summary>
        /// 进程终接器
        /// </summary>
        public static void DoRestFinalize()
        {
            Process[] p = Process.GetProcesses(Path.GetFileNameWithoutExtension("phantomjs.exe"));
            if (p != null)
            {
                foreach (Process pp in p)
                {
                    pp.Kill();
                }
            }
        }
    }
}
