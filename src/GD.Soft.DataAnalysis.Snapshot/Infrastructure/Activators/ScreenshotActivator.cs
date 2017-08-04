using GD.Soft.DataAnalysis.Snapshot.Entities;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace GD.Soft.DataAnalysis.Snapshot.Infrastructure.Activators
{
    /// <summary>
    /// 屏幕快照催化器
    /// </summary>
    public class ScreenshotActivator
    {
        /// <summary>
        /// 根据浏览器，初始化屏幕快照实例
        /// </summary>
        /// <param name="browser">浏览器</param>
        /// <returns>屏幕快照</returns>
        public virtual Screenshot ActivatorScreenshot(BrowserEntity browser)
        {
            if (this.doBrowserIsNull(browser)) throw new ArgumentNullException("浏览器未初始化");

            RemoteWebDriver webDriver = browser.Browser;
            PageActions PageActions = browser.PageActions;

            try
            {
                webDriver.Manage().Window.Maximize();
                webDriver.Navigate().GoToUrl(PageActions.Uri);
                this.SimulateOperation(webDriver, PageActions.preOpr);//执行操作等待页面加载完成
                Thread.Sleep(TimeSpan.FromSeconds(2));//再给页面加载，提供2秒的时间。
                this.DialogDismiss(webDriver);//隐藏对话框
                this.ExecuteScript(webDriver, PageActions.preScript);
                this.SimulateOperation(webDriver, PageActions.postOpr);//执行操作等待图表加载完成
                this.DialogDismiss(webDriver);//隐藏对话框
                this.ExecuteScript(webDriver, PageActions.postScript);
                this.AlertDismiss(webDriver);//隐藏提示框
                this.DialogDismiss(webDriver);//隐藏对话框
                this.EndpointHandler(webDriver);//终结点处理
                Thread.Sleep(TimeSpan.FromSeconds(2));//再给图表加载，提供2秒的时间。
                var screenShot = webDriver.GetScreenshot();//截图
                return screenShot;
            }
            finally
            {
                webDriver.Close();
                webDriver.Dispose();
            }
        }

        /// <summary>
        /// 摘要：
        ///     表示一个模拟页面操作的通用方法
        /// </summary>
        /// <param name="webDriver">浏览器</param>
        /// <param name="opr">要模拟的页面操作</param>
        public virtual void SimulateOperation(IWebDriver webDriver, Operation opr)
        {
            if (null != opr.Action) opr.Action(webDriver);
            var driverWait = new WebDriverWait(webDriver, opr.Timeout);
            if (null != opr.PollingInterval) driverWait.PollingInterval = opr.PollingInterval;
            if (null != opr.Condition) driverWait.Until(opr.Condition);
        }

        /// <summary>
        /// 摘要：
        ///     表示一个关闭对话框的方法
        /// </summary>
        /// <param name="wd">浏览器</param>
        public virtual void DialogDismiss(IWebDriver wd)
        {
            try
            {
                var eles = wd.FindElements(By.ClassName("ui-dialog"));
                if (null != eles && eles.Count() > 0)
                    foreach (var ele in eles)
                        this.ExecuteScript(wd, new JSScript() { Code = @"$('button[i-id=""ok""]').click();" });
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 摘要：
        ///     表示一个执行脚本的通用方法
        /// </summary>
        /// <param name="webDriver">浏览器</param>
        /// <param name="script">要执行的JS脚本</param>
        public virtual void ExecuteScript(dynamic webDriver, JSScript script)
        {
            if (null != script && !string.IsNullOrEmpty(script.Code))//执行JS脚本
                webDriver.ExecuteScript(script.Code, script.Agrs);
        }

        /// <summary>
        /// 摘要：
        ///     表示一个关闭浏览器弹出框的方法
        /// </summary>
        public virtual void AlertDismiss(IWebDriver wd)
        {
            try
            {
                IAlert alert = wd.SwitchTo().Alert();
                if (alert != null) alert.Dismiss();
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 摘要：
        ///     表示截屏前终结点处理的方法
        /// </summary>
        /// <param name="wd">浏览器</param>
        public virtual void EndpointHandler(IWebDriver wd)
        {
            try
            {
                this.ExecuteScript(wd, new JSScript() { Code = @"$('#showMenuButton').hide();" });//关闭菜单
                this.ExecuteScript(wd, new JSScript() { Code = @"$('#body').css('overflow','hidden');" });//隐藏滚动条
            }
            catch (Exception ex) { }
        }

        private bool doBrowserIsNull(BrowserEntity browser)
        {
            return null == browser ||
                null == browser.Browser ||
                null == browser.PageActions;
        }
    }
}
