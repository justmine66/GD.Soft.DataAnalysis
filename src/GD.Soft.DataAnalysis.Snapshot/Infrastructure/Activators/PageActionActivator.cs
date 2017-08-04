using GD.Soft.DataAnalysis.Snapshot.Entities;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Exceptions;
using GD.Soft.DataAnalysis.Snapshot.ValueObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Activators
{
    /// <summary>
    /// 页面行为催化器
    /// </summary>
    public class PageActionActivator
    {
        /// <summary>
        /// 根据条件，初始化页面行为实例
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>页面行为</returns>
        public virtual PageActions ActivatePageActions(FilterItem filter)
        {
            //1、初始化脚本、操作
            //1.1 获取模块特定脚本
            string preScriptLiteral = ConstDefines.PageActionsConsts.CommonPreScript;
            string postScriptLiteral = ConstDefines.PageActionsConsts.CommonPostScript;
            var pageName = this.GetPageNameFromUrl(filter.Url).Replace("/", "").Replace(@"\", "");
            var moduleName = string.Concat(pageName, "_", filter.ModuleKey);
            PageScripts moduleScript = this.GetScriptOnPageName(moduleName);
            if (null != moduleScript)
            {
                if (!string.IsNullOrWhiteSpace(moduleScript.PreOpr))
                    preScriptLiteral = string.Concat(preScriptLiteral, moduleScript.PreOpr);
                if (!string.IsNullOrWhiteSpace(moduleScript.PostOpr))
                    postScriptLiteral = string.Concat(postScriptLiteral, moduleScript.PostOpr);
            }
            //1.2 获取模块超时配置信息
            TimeoutSet timeoutSet = this.GetTimeOutConfigInfoOnPageName(pageName);
            //1.3 整合脚本、操作
            var preOpr = new Operation()
            {
                PollingInterval = TimeSpan.FromSeconds(2),
                Timeout = (
                    timeoutSet != null && timeoutSet.PageLoadTimeout.Seconds > 0 ?
                    timeoutSet.PageLoadTimeout :
                    TimeSpan.FromSeconds(10)),
                Condition = webDriver =>
                {
                    try
                    {
                        Console.WriteLine("......正在等待页面加载.....");
                        var byPath = By.XPath(@"//*[@id='inputIsLoaded']");
                        var ele = webDriver.FindElement(byPath);
                        return null != ele && ele.GetAttribute("isPageLoaded").Trim() == "1";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("......页面加载出现异常.....");
                        return false;
                    }
                }
            };
            var preScript = new JSScript()
            {
                //先隐藏检索条件窗体，然后赋上我们的值。
                Code = string.Format(preScriptLiteral, filter.Filter)
            };
            var postOpr = new Operation()
            {
                Action = webDriver =>
                {
                    webDriver.FindElement(By.XPath(@"//*[@id='SearchBtn']")).Click();
                },
                PollingInterval = TimeSpan.FromSeconds(2),
                Timeout = (
                    timeoutSet != null && timeoutSet.ChartLoadTimeout.Seconds > 0 ?
                    timeoutSet.ChartLoadTimeout :
                    TimeSpan.FromSeconds(10)),
                Condition = webDriver =>
                {
                    Console.WriteLine("......正在等待图表加载.....");
                    this.DialogCapture(webDriver, "EmptyNote");//先过滤脚本异常
                    try
                    {
                        var byPath = By.XPath(@"//*[@id='inputIsLoaded']");
                        var ele = webDriver.FindElement(byPath);
                        return null != ele && ele.GetAttribute("isChartLoaded").Trim() == "1";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("......图表加载出现异常.....");
                        return false;
                    }
                }
            };
            var postScript = new JSScript() { Code = postScriptLiteral };
            //2、初始化页面行为操作实例
            var pageActions = new PageActions();
            pageActions.Uri = new Uri(filter.Url);
            pageActions.preOpr = preOpr;
            pageActions.preScript = preScript;
            pageActions.postOpr = postOpr;
            pageActions.postScript = postScript;
            pageActions.BrowserOptions = filter.Browser;
            return pageActions;
        }

        /// <summary>
        /// 从Url中检索页面名称
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        private string GetPageNameFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }
            try
            {
                Uri uri = new Uri(url);
                var pageName = string.Empty;
                if (uri.Segments.Length > 0)
                {
                    foreach (var seq in uri.Segments)
                    {
                        if (seq.Contains("Analysis"))//只针对专题分析有效
                        {
                            pageName = seq;
                        }
                    }
                }
                return pageName;
            }
            catch (Exception ex)
            {
                throw new SnapshotBuildException("Url不合法或找不到", ex);
            }
        }

        /// <summary>
        /// 根据页面名称从系统中检索超时配置信息
        /// </summary>
        /// <param name="pageName">模块名称</param>
        /// <returns></returns>
        private TimeoutSet GetTimeOutConfigInfoOnPageName(string pageName)
        {
            TimeoutSet result;
            pagesTimeoutDic.TryGetValue(pageName, out result);
            return result;
        }

        /// <summary>
        /// 根据页面名称检索出指定脚本
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        private PageScripts GetScriptOnPageName(string pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName)) return null;
            var script = new PageScripts();
            pageScriptsDic.TryGetValue(pageName, out script);
            return script;
        }

        /// <summary>
        /// 页面自动控制操作前、后置脚本映射字典
        /// </summary>
        private ConcurrentDictionary<string, PageScripts> pageScriptsDic = new ConcurrentDictionary<string, PageScripts>()
        {
            //字典键组成规则：页面名称+模块名称首拼；若页面、模块名称发生变动，请根据实际需求修改映射。
            ["DJLAnalysis_DJZB"] = PageScripts.PageScriptsPreOpr("$('#RegProBtn').prop('checked',true);"),
            ["DJLAnalysis_QDZB"] = PageScripts.PageScriptsPreOpr("$('#RegProBtn').prop('checked',false);"),
            ["FZLAnalysis_ZMZB"] = PageScripts.PageScriptsPreOpr("$('#ProveBtn').prop('checked',true);"),
            ["FZLAnalysis_QDMX"] = PageScripts.PageScriptsPreOpr("$('#ProveBtn').prop('checked',false);$('#CertificateBtn').prop('checked',false);"),
            ["BDCDYAnalysis_FWZB"] = PageScripts.PageScriptsPreOpr("$('#houseBtn').prop('checked',true);"),
            ["BDCDYAnalysis_QDMX"] = PageScripts.PageScriptsPreOpr("$('#soilBtn').prop('checked',false);"),
            ["DJRLTAnalysis_RLT"] = new PageScripts("$('.search_area').show();$('#InputHiddeFormData').attr('isUse','1');$('#InputHiddeFormData').val('{0}');$('#main_context').parent().css('padding','0');$('#main_context').css('width','100%');",
                "$('.search_area').hide();"),
            ["XTGXAnalysis_QDMX"] = PageScripts.PageScriptsPreOpr("$('#DepAnalysisBtn').prop('checked',false);"),
            ["GXCXAnalysis_QDMX"] = PageScripts.PageScriptsPreOpr("$('#OAAnalysisBtn').prop('checked',false);"),
            ["QLDJXZAnalysis_QDMX"] = PageScripts.PageScriptsPreOpr("$('#StatusAnalysisBtn').prop('checked',false);"),
        };

        /// <summary>
        /// 等待页面、图表的超时时间映射字典
        /// </summary>
        private ConcurrentDictionary<string, TimeoutSet> pagesTimeoutDic = new ConcurrentDictionary<string, TimeoutSet>()
        {
            ["DJRLTAnalysis"] = new TimeoutSet(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(15))
        };

        /// <summary>
        /// 摘要：
        ///     表示一个捕获对话框的方法
        /// </summary>
        /// <param name="wd">浏览器</param>
        public virtual void DialogCapture(IWebDriver wd, string ClassName)
        {
            var eles = wd.FindElements(By.ClassName(ClassName));
            if (null != eles && eles.Count() > 0)
            {
                string msg = string.Empty;
                foreach (var ele in eles)
                {
                    msg = msg + ele.Text + @"\t";
                }
                throw new SnapshotBuildException(msg);
            }
        }
    }
}
