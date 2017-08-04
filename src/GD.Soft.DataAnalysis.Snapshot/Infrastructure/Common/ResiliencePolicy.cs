using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Exceptions;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Common
{
    /// <summary>
    /// 弹性策略
    /// 说明：处理瞬时容错
    /// </summary>
    public class ResiliencePolicy
    {
        public static ResiliencePolicy New { get { return new ResiliencePolicy(); } }

        /// <summary>
        /// 实时次数
        /// </summary>
        public static int NumOfTime { get; private set; }

        /// <summary>
        /// 弹性重试
        /// </summary>
        public virtual void ReTry(Action action, int ReTryCount)
        {
            NumOfTime = 0;
            var policy = RetryPolicy.Handle<Exception>()
                    .Retry(ReTryCount, (ex, time, cxt) =>
                     {
                         NumOfTime = time;
                         Console.WriteLine(@"第" + time + "次截图失败 \n 异常：" + ex.ToString());
                     });
            policy.Execute(() =>
            {
                action();
            });
        }
    }
}
