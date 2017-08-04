using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.ValueObjects
{
    /// <summary>
    /// 浏览器选项
    /// </summary>
    public enum Enum_BrowserOptions
    {
        None = 0,
        IE,
        PhantomJS
    }

    /// <summary>
    /// JS脚本执行次序选项
    /// </summary>
    public enum Enum_ScriptExecOptions
    {
        None = 0,
        /// <summary>
        /// 页面操作前执行
        /// </summary>
        preOpr,
        /// <summary>
        /// 页面操作后执行
        /// </summary>
        postOpr
    }

    /// <summary>
    /// 页面操作执行次序选项
    /// </summary>
    public enum Enum_OprExecOptions
    {
        None = 0,
        /// <summary>
        /// 脚本前执行
        /// </summary>
        preOpr,
        /// <summary>
        /// 脚本后执行
        /// </summary>
        postOpr
    }
}
