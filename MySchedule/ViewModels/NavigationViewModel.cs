using MySchedule.Extensions;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.ViewModels
{
    //导航
    public class NavigationViewModel : BindableBase,INavigationAware
    {
        private readonly IContainerProvider containerProvider;
        //事件聚合器
        public readonly IEventAggregator eventAggregator;

        public NavigationViewModel(IContainerProvider containerProvider)
        {
            this.containerProvider = containerProvider;
            eventAggregator = containerProvider.Resolve<IEventAggregator>();
        }
        //是否处于加载状态
        public void UpdateLoading(bool IsOpen)
        {
            eventAggregator.UpdateLoading(new Common.Events.UpdateModel()
            {
                IsOpen = IsOpen
            });
        }
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        //
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
