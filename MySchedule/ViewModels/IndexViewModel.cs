using MySchedule.Common.Models;
using MySchedule.Shared.Dtos;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MemoDto = MySchedule.Shared.Dtos.MemoDto;
//using ToDoDto = MySchedule.Shared.Dtos.ToDoDto;

namespace MySchedule.ViewModels
{
    internal class IndexViewModel:BindableBase
    {
        public IndexViewModel()
        {
            TaskBars = new ObservableCollection<TaskBar>();
            CreateTaskBars();

            CreateTestData();
        }

        //任务栏的数据集合
        private ObservableCollection<TaskBar> taskBars;

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }
        public void CreateTaskBars()
        {
            TaskBars.Add(new TaskBar() { Icon = "ClockFast", Title = "汇总", Color = "#FF0CA0FF", Target = "ToDoView" ,Content="9"});
            TaskBars.Add(new TaskBar() { Icon = "ClockCheckOutline", Title = "已完成", Color = "#FF1ECA3A", Target = "ToDoView",Content="9"});
            TaskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "完成比例", Color = "#FF02C6DC", Target = "" ,Content="100%"});
            TaskBars.Add(new TaskBar() { Icon = "PlaylistStar", Title = "备忘录", Color = "#FFFFA000", Target = "MemoView" ,Content="19"});
        }

        //代办事项的数据集合
        private ObservableCollection<ToDoDto> toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }
        //备忘录的数据集合
        private ObservableCollection<Shared.Dtos.MemoDto> memoDtos;

        public ObservableCollection<Shared.Dtos.MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }

        public void CreateTestData()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<Shared.Dtos.MemoDto>();
            for (int i = 0; i < 10; i++)
            {
                ToDoDtos.Add(new ToDoDto() {Title="待办"+i,Content="正在处理..." });

                MemoDtos.Add(new Shared.Dtos.MemoDto() {Title="备忘"+i,Content="密码是..." });
            }

        }


    }
}
