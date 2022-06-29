using MySchedule.Common.Models;
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
    internal class ToDoViewModel : BindableBase
    {
        public ToDoViewModel()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            CreateToDoList();

            AddCommand = new DelegateCommand(Add);
        }

        //待办事项的数据集合
        private ObservableCollection<ToDoDto> toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        //添加待办事项的命令
        public DelegateCommand AddCommand { get; private set; }
        //添加待办事项，是否展开右侧的菜单栏
        private bool isRightDrawerOpen;

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }


        void CreateToDoList()
        {
            for (int i = 0; i < 10; i++)
            {
                ToDoDtos.Add(new ToDoDto() { Title = "待办" + i, Content = "正在处理..." });

            }
        }

        void Add()
        {
            IsRightDrawerOpen = true;
        }
    }
}
