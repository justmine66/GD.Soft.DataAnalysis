using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.IntegrationEvents.Events
{
    /// <summary>
    /// 错误引发事件
    /// </summary>
    public class OnErroredIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// 地址
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// 异常
        /// </summary>
        public SnapshotBuildException Exception { get; private set; }

        /// <summary>
        /// 初始化错误引发事件
        /// </summary>
        /// <param name="uri">地址</param>
        /// <param name="exception">异常</param>
        public OnErroredIntegrationEvent(Uri uri, SnapshotBuildException exception)
        {
            this.Uri = uri;
            this.Exception = exception;
        }
    }
}
