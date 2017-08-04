using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services.Abstractions
{
    /// <summary>
    /// 本地文件系统服务
    /// </summary>
    public interface ILocalFilesSystemService
    {
        /// <summary>
        /// 表示一个异步保存到本地文件的任务
        /// </summary>
        /// <param name="Screenshot">快照</param>
        /// <returns></returns>
        Task SaveSingleFileAsync(Screenshot screenshot);

        /// <summary>
        /// 表示一个同步保存到本地文件的方法
        /// </summary>
        /// <param name="Screenshot">快照</param>
        /// <returns></returns>
        void SaveSingleFile(Screenshot screenshot);
    }
}
