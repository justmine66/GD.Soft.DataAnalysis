var page = require('webpage').create();//创建webpage对象
var sys = require('system');//创建system对象
var t = 0;//页面加载时间赋初值
var address = sys.args[1];//页面加载的地址为参数sys.args[1]

if (sys.args.length === 1) {
    console.log('please input like this:phantomjs firstLoadPage.js <some url>');
    phantom.exit();
}else{
    page.onLoadStarted = function () {
        page.startTime = new Date();
    };//获取页面开始加载的时间
    page.viewportSize = { width: 960, height: 2000 };//设置可视界面宽高

    page.open(address,function(status){//页面加载状态为success、fail两种
        if (status !== 'success') {//状态为fail时，控制台打印，载入页面失败，然后退出
            console.log('Fail to load the page!');
            phantom.exit();
        }else{//状态为success时，加载页面成功，计算页面加载时间,并在控制台打印加载时间，退出
            t = Date.now() - page.startTime;//页面加载完成后的当前时间减去页面开始加载的时间，为整个页面加载时间
            console.log('firstLoadPage time :'+ t +'ms');
            phantom.exit();
        };
    });
};