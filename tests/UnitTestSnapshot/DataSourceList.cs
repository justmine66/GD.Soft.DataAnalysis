using GD.Soft.DataAnalysis.Snapshot.Entities;
using GD.Soft.DataAnalysis.Snapshot.ValueObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestSnapshot
{
    /// <summary>
    /// 测试用例
    /// </summary>
    public class DataSourceList
    {
        public List<FilterItem> GetSources()
        {
            //地址请保持实时更新，避免登录过期，一般截图失败都是由于登录过期引起的。
            var sjsb_url = @"http://192.168.103.107:8080/hnbdc/BDCInfoCount/SJSBAnalysis/Index?Skin=default&userID=410800000209&menuTop=170&loginTime=636373537951989089&opHeight=970&v=636373541911843793";
            var sjjr_url = @"http://192.168.103.107:8080/hnbdc/BDCInfoCount/SJJRAnalysis/Index?Skin=default&userID=410800000209&menuTop=170&loginTime=636373537951989089&opHeight=970&v=636373579388854568";
            var bdcdj_url = @"http://192.168.103.107:8080/hnbdc/BDCInfoCount/BDCDYAnalysis/Index?Skin=default&userID=410800000209&menuTop=170&loginTime=636371186469928214&opHeight=970&v=636371195194669610";
            var fzl_url = @"http://192.168.103.107:8080/hnbdc/BDCInfoCount/FZLAnalysis/Index?Skin=default&userID=410800000209&menuTop=170&loginTime=636371186469928214&opHeight=970&v=636371186633699951";
            var djl_url = @"http://192.168.103.107:8080/hnbdc/BDCInfoCount/DJRLTAnalysis/Index?Skin=default&userID=410800000209&menuTop=170&loginTime=636373537951989089&opHeight=970&v=636373538273855712";
            var djrlt_url = @"http://192.168.103.107:8080/hnbdc/BDCInfoCount/DJRLTAnalysis/Index?Skin=default&userID=410800000209&menuTop=170&loginTime=636371186469928214&opHeight=970&v=636371200469431309";
            var xtgxfx_url = @"http://192.168.103.107:8080/hnbdc/BDCInfoCount/XTGXAnalysis/Index?Skin=default&userID=410800000209&menuTop=170&loginTime=636371100661765622&opHeight=970&v=636371107328613959";
            var gxcxfx_url = @"http://192.168.103.107:8080/hnbdc/BDCInfoCount/GXCXAnalysis/Index?Skin=default&userID=410800000209&menuTop=170&loginTime=636371770689085785&opHeight=970&v=636371775623069101";
            var qldjxz_fx = @"http://192.168.103.107:8080/hnbdc/BDCInfoCount/QLDJXZAnalysis/Index?Skin=default&userID=410800000209&menuTop=170&loginTime=636371770689085785&opHeight=970&v=636371780747072397";

            //测试用例
            var sources = new List<FilterItem>();
            sources.Add(new FilterItem("数据上报", sjsb_url,
                "SelectedPeriodCategorys=year&Year=2017&An=true&An=false&Mom=true&Mom=false&selectedAnalysisThematics=IntervalDetailSJSB"));

            sources.Add(new FilterItem("数据接入", sjjr_url,
                "SelectedPeriodCategorys=month&ReportStartTime=2017-06-01&ReportEndTime=2017-06-30&selectedAnalysisThematics=AccessCompareSJJR&An=false&Mom=false", Enum_BrowserOptions.IE));
            sources.Add(new FilterItem("数据接入-期段明细", sjjr_url,
                "SelectedPeriodCategorys=month&ReportStartTime=2017-06-01&ReportEndTime=2017-06-30&selectedAnalysisThematics=IntervalDetailSJJR&An=false&Mom=false"));

            //sources.Add(new FilterItem("协同共享分析-部门分析", xtgxfx_url,
            //    "SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=DepAnalysisXTGX&DataSelections_push=false&DataSelections_receive=false&An=false&Mom=false"));
            //sources.Add(new FilterItem("协同共享分析-期段明细", "QDMX", xtgxfx_url,
            //    "SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=IntervalDetailXTGX&DataSelections_push=true&DataSelections_push=false&DataSelections_receive=true&DataSelections_receive=false&An=false&Mom=true&Mom=false", Enum_BrowserOptions.IE));

            //sources.Add(new FilterItem("共享查询分析-机构分析", gxcxfx_url,
            //    "SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=OAAnalysisGXCX&An=false&Mom=false"));
            //sources.Add(new FilterItem("共享查询分析-期段明细", "QDMX", gxcxfx_url,
            //    "SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=IntervalDetailGXCX&An=true&An=false&Mom=true&Mom=false", Enum_BrowserOptions.IE));

            //sources.Add(new FilterItem("登记量分析-登记占比", "DJZB", djl_url,
            //    "SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=RegProDJL&An=false&Mom=false", Enum_BrowserOptions.IE));
            //sources.Add(new FilterItem("登记量分析-期段占比", "QDZB", djl_url,
            //"SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=IntervalDetailDJL&An=true&An=false&Mom=true&Mom=false", Enum_BrowserOptions.IE));

            //sources.Add(new FilterItem("权利登记现状分析", qldjxz_fx,
            //    "SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=StatusAnalysisQLDJXZ&An=false&Mom=false", Enum_BrowserOptions.IE));
            //sources.Add(new FilterItem("权利登记现状分析-期段明细", "QDMX", qldjxz_fx,
            //    "SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=IntervalDetailQLDJXZ&An=true&An=false&Mom=true&Mom=false"));

            //sources.Add(new FilterItem("发证量分析-证书占比", fzl_url,
            //    @"SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=CertificateFZL&An=false&Mom=false", Enum_BrowserOptions.IE));
            //sources.Add(new FilterItem("发证量分析-证明占比","ZMZB", fzl_url,
            //    @"SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=ProveFZL&An=false&Mom=false", Enum_BrowserOptions.IE));
            //sources.Add(new FilterItem("发证量分析-期段明细", "QDMX", fzl_url,
            //    @"SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=IntervalDetailFZL&An=false&Mom=false", Enum_BrowserOptions.IE));
            //sources.Add(new FilterItem("发证量分析-期段明细-同|环比", "QDMX", fzl_url,
            //    @"SelectedPeriodCategorys=year&Year=2017&selectedAnalysisThematics=IntervalDetailFZL&An=true&An=false&Mom=true&Mom=false", Enum_BrowserOptions.IE));

            //sources.Add(new FilterItem("不动产登记分析-土地占比", bdcdj_url,
            //    @"SelectedPeriodCategorys=month&ReportStartTime=2017-05-01&ReportEndTime=2017-05-31&selectedAnalysisThematics=LandRatioBDCDY&SelectedSoilbdctypes=&SelectedHousePropertys=&SelectedBDCTypes=&SelectedCounttypes=AddNums", Enum_BrowserOptions.IE));
            //sources.Add(new FilterItem("不动产登记分析-房屋占比", "FWZB", bdcdj_url,
            //    @"SelectedPeriodCategorys=month&ReportStartTime=2017-05-01&ReportEndTime=2017-05-31&selectedAnalysisThematics=HouseRatioBDCDY&SelectedSoilbdctypes=&SelectedHousePropertys=&SelectedBDCTypes=&SelectedCounttypes=AddNums", Enum_BrowserOptions.IE));
            //sources.Add(new FilterItem("不动产登记分析-期段明细", "QDMX", bdcdj_url,
            //    @"SelectedPeriodCategorys=month&ReportStartTime=2017-05-01&ReportEndTime=2017-05-31&selectedAnalysisThematics=IntervalDetailBDCDY&SelectedSoilbdctypes=&SelectedHousePropertys=&SelectedBDCTypes=&SelectedCounttypes=AddNums", Enum_BrowserOptions.IE));

            //热力图需用IE浏览器模拟。
            sources.Add(new FilterItem("登记热力图", "RLT", djrlt_url, @"SelectedPeriodCategorys=year&Year=2017", Enum_BrowserOptions.IE));

            return sources;
        }
    }
}
