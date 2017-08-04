using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Entities
{
    /// <summary>
    /// 操作
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// 行为操作
        /// </summary>
        public Action<IWebDriver> Action { get; set; }

        /// <summary>
        /// 条件函数
        /// </summary>
        public Func<IWebDriver, bool> Condition { get; set; }

        /// <summary>
        /// 多久后评估条件
        /// </summary>
        public TimeSpan PollingInterval { get; set; }

        /// <summary>
        /// 条件超时时间
        /// </summary>
        public TimeSpan Timeout { get; set; }
    }
}
