using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.IntegrationEvents
{
    /// <summary>
    /// 摘要：
    ///     事件源基类型，所有的事件源都要实现此类。
    /// 说明：
    ///     包含一个事件处理所需的信息，也叫事件源；根据事件源可以区分出不同的事件(统称)，也可按用途称为事件类型。
    /// </summary>
    public class IntegrationEvent : EventArgs
    {
        /// <summary>
        /// 初始化一个事件实例
        /// </summary>
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreationDate { get; }
    }
}
