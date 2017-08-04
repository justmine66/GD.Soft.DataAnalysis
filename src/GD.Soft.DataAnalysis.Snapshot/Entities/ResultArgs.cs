using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Entities
{
    /// <summary>
    /// 结果参数
    /// </summary>
    public class ResultArgs
    {
        /// <summary>
        /// 快照原副本
        /// </summary>
        public Screenshot Screenshot { get; private set; }

        /// <summary>
        /// 图片服务器本机全路径
        /// </summary>
        public string LocalPath { get; private set; }

        /// <summary>
        /// 初始化一个结果参数实例
        /// </summary>
        /// <param name="screenshot">快照原副本</param>
        /// <param name="localPath">图片服务器本机全路径</param>
        public ResultArgs(Screenshot screenshot,string localPath)
        {
            this.LocalPath = localPath;
            this.Screenshot = screenshot;
        }
    }
}
