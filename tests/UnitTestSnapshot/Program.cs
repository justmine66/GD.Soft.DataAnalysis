using GD.Soft.DataAnalysis.Snapshot;
using GD.Soft.DataAnalysis.Snapshot.Entities;
using GD.Soft.DataAnalysis.Snapshot.Infrastructure.Services;
using GD.Soft.DataAnalysis.Snapshot.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UnitTestSnapshot
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取测试用例
            var examples = new DataSourceList().GetSources();
            foreach (var example in examples)
            {
                //1、初始化快照引擎
                var engine = new SnapshotEngine();
                //2、注册参数
                //2.1 设置容错重试参数
                engine.SetReTryCount(1);
                //2.2 事件（进度监控、异常捕获）
                engine.OnStarted += (s, e) =>
                {
                    Console.WriteLine(string.Format("\n开始截图，\n地址：{0} \n时间：{1}；\n", e.Uri, e.CreationDate));
                };
                engine.OnCompleted += (s, e) =>
                {
                    Console.WriteLine(
                        string.Format("\n标识：{0}；\n截图完成，\n耗时：{1}；\n线程：{2}；\n图片路径：{3}；\n完成事件：{4}；\n",
                        e.Id,
                        e.Elapsed.ToString(),
                        e.TheadId,
                        e.ResultArgs.LocalPath,
                        e.CreationDate));
                    if (File.Exists(e.ResultArgs.LocalPath))
                    {
                        Console.WriteLine("文件已成功保存");
                    }
                };
                engine.OnErrored += (s, e) =>
                {
                    Console.WriteLine(string.Format("\n截图出现错误，\n地址：{0} \n时间：{1}；\n异常：{2} {3}；\n"
                        , e.Uri, e.CreationDate,
                        e.Exception.Message, e.Exception.InnerException == null ? string.Empty : e.Exception.InnerException.Message));
                };
                //3、传入筛选条件，启动引擎
                engine.Start(example);
            }
            //Console.Read();
        }
    }
}
