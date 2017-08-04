using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Entities
{
    /// <summary>
    /// 页面脚本
    /// </summary>
    public class PageScripts
    {
        public string PreOpr { get; set; }
        public string PostOpr { get; set; }

        public PageScripts() { }

        public PageScripts(string preOpr, string postOpr)
        {
            this.PreOpr = preOpr;
            this.PostOpr = postOpr;
        }

        public static PageScripts PageScriptsPreOpr(string preOpr)
        {
            return new PageScripts(preOpr, string.Empty);
        }

        public static PageScripts PageScriptsPostOpr(string postOpr)
        {
            return new PageScripts(string.Empty, postOpr);
        }
    }
}
