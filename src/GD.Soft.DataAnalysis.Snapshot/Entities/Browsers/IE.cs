using GD.Soft.DataAnalysis.Snapshot.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
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
    ///     IE浏览器
    /// </summary>
    public class IE
    {
        private static readonly string driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Components/IE");

        #region 单子实例

        private static readonly Lazy<InternetExplorerDriver> _webDriver = new Lazy<InternetExplorerDriver>(() =>
        {
            var options = new InternetExplorerOptions() { IntroduceInstabilityByIgnoringProtectedModeSettings = true };
            return new InternetExplorerDriver(driverPath, options);
        });
        public static InternetExplorerDriver Singleton { get { return _webDriver.Value; } }

        #endregion

        public static InternetExplorerDriver New
        {
            get
            {
                var options = new InternetExplorerOptions() { IntroduceInstabilityByIgnoringProtectedModeSettings = true };
                return new InternetExplorerDriver(driverPath, options);
            }
        }

        /// <summary>
        /// 进程终接器
        /// </summary>
        public static void DoRestFinalize()
        {
            Process[] p = Process.GetProcesses(Path.GetFileNameWithoutExtension("IEDriverServer.exe"));
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
