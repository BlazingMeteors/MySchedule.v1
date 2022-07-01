//using MySchedule.Common.Models;
using MySchedule.Service;
using MySchedule.Shared.Dtos;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.ViewModels
{
    internal class MemoViewModel:BindableBase
    {
        public MemoViewModel(IMemoService service)
        {
            MemoDtos = new ObservableCollection<MemoDto>();

            AddCommand = new DelegateCommand(Add);
            this.service = service;
            CreateToDoList();

        }
        //备忘录的服务
        private readonly IMemoService service;

        //备忘录的数据集合
        private ObservableCollection<MemoDto> memoDtos;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }

        //添加备忘录的命令
        public DelegateCommand AddCommand { get; private set; }
        //添加备忘录，是否展开右侧的菜单栏
        private bool isRightDrawerOpen;

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }


        async void CreateToDoList()
        {
            var memoResult = await service.GetAllAsync(new Shared.QueryParams.QueryParameters()
            {
                PageIndex = 0,
                PageSize = 100,
            });
            if (memoResult.Status)
            {
                foreach (var item in memoResult.Result.Items)
                {
                    MemoDtos.Add(item);
                }
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    MemoDtos.Add(new MemoDto() { Title = "备忘录" + i, Content = "正在处理..." });

            //}
        }

        void Add()
        {
            IsRightDrawerOpen = true;
        }
    }
}
