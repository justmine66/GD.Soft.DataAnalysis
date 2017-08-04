using GD.Soft.DataAnalysis.Snapshot.Entities;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services.Abstractions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Activators
{
    /// <summary>
    /// 结果参数催化器
    /// </summary>
    public class ResultArgsActivator
    {
        /// <summary>
        /// 根据屏幕快照，初始化结果参数实例。
        /// </summary>
        /// <param name="snapshot">屏幕快照</param>
        /// <returns>结果参数</returns>
        public virtual ResultArgs ActivatorResultArgs(Screenshot snapshot)
        {
            var localfileService = new DefaultLocalFilesSystemService();
            //localfileService.SaveSingleFileAsync(snapshot);
            localfileService.SaveSingleFile(snapshot);
            var result = new ResultArgs(snapshot, localfileService.DefaultLocalPath);
            return result;
        }
    }
}
