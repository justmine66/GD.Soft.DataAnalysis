using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using System.IO;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services
{
    /// <summary>
    /// 默认本地文件系统服务
    /// </summary>
    public class DefaultLocalFilesSystemService : ILocalFilesSystemService
    {
        public string DefaultLocalPath { get; private set; }

        public DefaultLocalFilesSystemService()
        {
            var fileDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots");
            if (!Directory.Exists(fileDir)) Directory.CreateDirectory(fileDir);
            this.DefaultLocalPath = string.Format(@"{0}\{1}.png", fileDir, DateTime.UtcNow.ToBinary().ToString());
        }
        public DefaultLocalFilesSystemService(string localPath)
        {
            this.DefaultLocalPath = localPath;
        }

        /// <summary>
        /// 表示一个异步保存到本地文件的任务
        /// </summary>
        /// <param name="Screenshot">快照</param>
        /// <returns></returns>
        public virtual Task SaveSingleFileAsync(Screenshot screenshot)
        {
            return Task.Factory.StartNew(() =>
            {
                if (null != screenshot)
                    screenshot.SaveAsFile(this.DefaultLocalPath, ScreenshotImageFormat.Png);
            });
        }

        /// <summary>
        /// 表示一个同步保存到本地文件的方法
        /// </summary>
        /// <param name="Screenshot">快照</param>
        /// <returns></returns>
        public void SaveSingleFile(Screenshot screenshot)
        {
            if (null != screenshot)
                screenshot.SaveAsFile(this.DefaultLocalPath, ScreenshotImageFormat.Png);
        }
    }
}
