// See https://aka.ms/new-console-template for more information
using System.Reflection;
using TestTopshelf;
using Topshelf;

Console.WriteLine("Hello, World!");

//var x = new DoThing();
//x.StartAsync();

//var x = new TimerWork();
//x.Start();

//Console.ReadLine();

HostFactory.Run(x =>
{
    x.Service<TimerWork>(s =>
    {
        s.ConstructUsing(name => new TimerWork());
        s.WhenStarted(tc => tc.Start());
        s.WhenStopped(tc => tc.Stop());
    });
    x.RunAsLocalSystem();//使用 LocalSystem 帳號
    //x.StartAutomatically();//開機自動啟動
   // x.EnableServiceRecovery(rc => rc.RestartService(1));//直到錯誤計數重置的天數
    var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
    x.SetDescription("Sample Topshelf Host");//服務說明
    x.SetDisplayName(assemblyName);//服務顯示名稱
    x.SetServiceName(assemblyName);//服務名稱
});