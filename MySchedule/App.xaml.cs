using MySchedule.Service;
using MySchedule.ViewModels;
using MySchedule.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.DryIoc;
using DryIoc;

namespace MySchedule
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            //启动窗口
            return Container.Resolve<MainView>();
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //依赖注入注册服务
            containerRegistry.GetContainer().Register<HttpRestClient>(made:Parameters.Of.Type<string>(serviceKey: "webUrl"));
            //服务地址
            containerRegistry.GetContainer().RegisterInstance(@"http://localhost:12161/", serviceKey: "webUrl");
            //注册服务
            containerRegistry.Register<IToDoService,ToDoService>();
            containerRegistry.Register<IMemoService, MemoService>();


            //Prism区域导航
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
            containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();

        }
    }
}
