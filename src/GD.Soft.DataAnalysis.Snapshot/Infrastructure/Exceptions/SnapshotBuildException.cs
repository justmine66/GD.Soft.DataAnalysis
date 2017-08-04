using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Exceptions
{
    /// <summary>
    /// 快照生成异常
    /// </summary>
    public class SnapshotBuildException : Exception
    {
        public SnapshotBuildException() : base() { }
        public SnapshotBuildException(string message) : base(message) { }
        public SnapshotBuildException(string message, Exception innerException) : base(message, innerException) { }
    }
}
