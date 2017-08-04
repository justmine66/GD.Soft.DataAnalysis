using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Entities
{
    /// <summary>
    /// JS脚本
    /// </summary>
    public class JSScript
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public object[] Agrs { get; set; }
    }
}
