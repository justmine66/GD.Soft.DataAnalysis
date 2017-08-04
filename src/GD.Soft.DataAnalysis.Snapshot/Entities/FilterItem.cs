using GD.Soft.DataAnalysis.Snapshot.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Entities
{
    /// <summary>
    /// 筛选条件
    /// </summary>
    public class FilterItem
    {
        public string Name { get; set; }
        public string ModuleKey { get; set; }
        public string Url { get; set; }
        public string Filter { get; set; }
        public Enum_BrowserOptions Browser { get; set; }

        public FilterItem(string name, string url, string filter, Enum_BrowserOptions browser = Enum_BrowserOptions.PhantomJS)
        {
            this.Name = name;
            this.Url = url;
            this.Filter = filter;
            this.Browser = browser;
        }

        /// <summary>
        /// 初始化筛选条件实例
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="moduleKey">模块键(eg：期段明细=》QDMX)</param>
        /// <param name="url">地址</param>
        /// <param name="filter">筛选条件</param>
        /// <param name="browser">浏览器</param>
        public FilterItem(string name, string moduleKey, string url, string filter, Enum_BrowserOptions browser = Enum_BrowserOptions.PhantomJS)
        {
            this.Name = name;
            this.ModuleKey = moduleKey;
            this.Url = url;
            this.Filter = filter;
            this.Browser = browser;
        }
    }
}
