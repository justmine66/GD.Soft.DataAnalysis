using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.ValueObjects
{
    /// <summary>
    /// 常量定义
    /// </summary>
    public static class ConstDefines
    {
        /// <summary>
        /// 页面行为常量
        /// </summary>
        public static class PageActionsConsts
        {
            /// <summary>
            /// 通用操作前置脚本
            /// </summary>
            public const string CommonPreScript = @"$('#InputHiddeFormData').attr('isUse','1');$('#InputHiddeFormData').val('{0}');$('.search_area').hide();$('.caption_name').hide();$('#PrintBtn').hide();$('#ExportBtn').hide();$('#main_context').parent().css('padding','0');$('#main_context').css('width','100%');";

            /// <summary>
            /// 通用操作后置脚本
            /// </summary>
            public const string CommonPostScript = @"$('#SearchBtn').hide();";
        }
    }
}
