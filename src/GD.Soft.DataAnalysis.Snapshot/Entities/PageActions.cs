using GD.Soft.DataAnalysis.Snapshot.ValueObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Entities
{
    /// <summary>
    /// 页面行为
    /// </summary>
    public class PageActions
    {
        /// <summary>
        /// 浏览器
        /// </summary>
        public Enum_BrowserOptions BrowserOptions { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// 前脚本
        /// </summary>
        public JSScript preScript { get; set; }

        /// <summary>
        /// 后脚本
        /// </summary>
        public JSScript postScript { get; set; }

        /// <summary>
        /// 前操作
        /// </summary>
        public Operation preOpr { get; set; }

        /// <summary>
        /// 后操作
        /// </summary>
        public Operation postOpr { get; set; }
    }
}
