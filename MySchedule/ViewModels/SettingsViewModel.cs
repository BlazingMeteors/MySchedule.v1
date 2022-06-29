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
    internal class SettingsViewModel:BindableBase
    {
        public SettingsViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            this.regionManager = regionManager;
            CreateMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
        }
        private ObservableCollection<MenuBar> menuBars;
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        //prism区域
        private readonly IRegionManager regionManager;
        //导航命令\日志
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }

        private void Navigate(MenuBar obj)
        {
            //判断是否传入所要导航到的界面的NameSpace
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
            {
                return;
            }
            regionManager.Regions[PrismManager.SettingsViewRegionName].RequestNavigate(obj.NameSpace);
        }

        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Palette", Title = "个性设置", NameSpace = "SkinView" });
            //MenuBars.Add(new MenuBar() { Icon = "NotebookOutline", Title = "系统设置", NameSpace = "" });
            MenuBars.Add(new MenuBar() { Icon = "Information", Title = "关于更多", NameSpace = "AboutView" });
            
        }


    }
}
