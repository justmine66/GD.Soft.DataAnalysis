var page = require('webpage').create();//创建webpage对象
var sys = require('system');//创建system对象
var address = sys.args[1];//页面加载的地址为参数sys.args[1]

if (sys.args.length === 1) {
    console.log('please input like this:phantomjs render.js <some url>');
    phantom.exit();
}else{
	page.viewportSize = { width: 960, height: 2000 };
    page.open(address,function(status){//页面加载状态为success、fail两种
        if (status !== 'success') {//状态为fail时，控制台打印，载入页面失败，然后退出
            console.log('Fail to load the page!');
            phantom.exit();
        }else{//状态为success时，加载页面成功，截图保存为test.png，退出
            page.render('test.png');
            phantom.exit();
        };
    });
};