using MySchedule.Common;
using MySchedule.Common.Models;
using MySchedule.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.ViewModels
{
    public class MainViewModel:BindableBase,IConfigureService
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        public MainViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            

            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this.regionManager = regionManager;

            //向前向后跳转
            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoBack)
                    journal.GoBack();
            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                    journal.GoForward();
            });


            
        }

        //左侧菜单栏的数据集合
        private ObservableCollection<MenuBar> menuBars;
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }
        //prism区域
        private readonly IRegionManager regionManager;
        //区域导航日志
        private IRegionNavigationJournal journal;
        //导航命令\日志
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        //向前跳转
        public DelegateCommand GoBackCommand { get; private set; }
        //向后跳转
        public DelegateCommand GoForwardCommand { get; private set; }      
        /// <summary>
        /// 首页跳转
        /// </summary>
        /// <param name="obj"></param>
        private void Navigate(MenuBar obj)
        {
            //判断是否传入所要导航到的界面的NameSpace
            if (obj==null ||string.IsNullOrWhiteSpace(obj.NameSpace))
            {
                return;
            }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace,back=>
            {
                journal = back.Context.NavigationService.Journal;
            });
        }

        /// <summary>
        /// 创建左侧菜单栏
        /// </summary>
        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "首页", NameSpace = "IndexView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookOutline", Title = "待办事项", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "设置", NameSpace = "SettingsView" });
        }


        /// <summary>
        /// 首页的初始界面设置为IndexView
        /// </summary>
        public void Configure()
        {
            UserName = AppSession.UserName;

            CreateMenuBar();
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("IndexView");
        }
    }
}
