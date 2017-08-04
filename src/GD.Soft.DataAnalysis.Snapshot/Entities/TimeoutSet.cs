using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Entities
{
    /// <summary>
    /// 超时设置
    /// </summary>
    public class TimeoutSet
    {
        /// <summary>
        /// 页面加载超时
        /// </summary>
        public TimeSpan PageLoadTimeout { get; set; }

        /// <summary>
        /// 图表加载超时
        /// </summary>
        public TimeSpan ChartLoadTimeout { get; set; }

        public TimeoutSet(TimeSpan pageLoadTimeout, TimeSpan chartLoadTimeout)
        {
            this.ChartLoadTimeout = chartLoadTimeout;
            this.PageLoadTimeout = pageLoadTimeout;
        }
    }
}
