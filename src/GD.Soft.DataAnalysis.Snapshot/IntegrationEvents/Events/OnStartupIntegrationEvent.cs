using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.IntegrationEvents.Events
{
    /// <summary>
    /// 启动事件
    /// </summary>
    public class OnStartupIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// 地址
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// 初始化启动事件
        /// </summary>
        /// <param name="uri">地址</param>
        public OnStartupIntegrationEvent(Uri uri)
        {
            this.Uri = uri;
        }
    }
}
