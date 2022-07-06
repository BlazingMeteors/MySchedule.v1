using MySchedule.Common;
using MySchedule.Common.Models;
using MySchedule.Extensions;
using MySchedule.Service;
using MySchedule.Shared.Dtos;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
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
    public class IndexViewModel: NavigationViewModel
    {
        private readonly IDialogHostService dialog;
        private readonly IToDoService toDoService;
        private readonly IMemoService memoService;
        private readonly IRegionManager regionManager;

        public IndexViewModel(IContainerProvider provider
            ,IDialogHostService dialog):base(provider)
        {
            Title = $"你好，{AppSession.UserName}，{DateTime.Now.GetDateTimeFormats('D')[1].ToString()}";
            //ToDoDtos = new ObservableCollection<ToDoDto>();
            //MemoDtos = new ObservableCollection<Shared.Dtos.MemoDto>();
            TaskBars = new ObservableCollection<TaskBar>();
            CreateTaskBars();


            this.toDoService = provider.Resolve<IToDoService>();
            this.memoService = provider.Resolve<IMemoService>();
            this.regionManager = provider.Resolve<IRegionManager>();
            this.dialog = dialog;   

            ExecuteCommand = new DelegateCommand<string>(Execute);
            EditMemoCommand = new DelegateCommand<MemoDto>(AddMemo);
            EditToDoCommand = new DelegateCommand<ToDoDto>(AddToDo);
            ToDoCompltedCommand = new DelegateCommand<ToDoDto>(Complted);
            NavigateCommand = new DelegateCommand<TaskBar>(Navigate);
        }
        //首页界面上的日期消息
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
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
            
            TaskBars.Add(new TaskBar() { Icon = "ClockFast", Title = "汇总", Color = "#FF0CA0FF", Target = "ToDoView" });
            TaskBars.Add(new TaskBar() { Icon = "ClockCheckOutline", Title = "已完成", Color = "#FF1ECA3A", Target = "ToDoView"});
            TaskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "完成比例", Color = "#FF02C6DC", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "PlaylistStar", Title = "备忘录", Color = "#FFFFA000", Target = "MemoView" });
        }

        //
        public DelegateCommand<ToDoDto> ToDoCompltedCommand { get; private set; }
        /// <summary>
        /// 首页拨动开关：已完成/待办
        /// </summary>
        /// <param name="obj"></param>
        private async void Complted(ToDoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var updateResult = await toDoService.UpdateAsync(obj);
                if (updateResult.Status)
                {
                    var todo = summary.ToDoList.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (todo != null)
                    {
                        summary.ToDoList.Remove(todo);
                        summary.CompletedCount += 1;
                        summary.CompletedRatio = (summary.CompletedCount / (double)summary.Sum).ToString("0%");
                        this.Refresh();
                    }
                    //aggregator.SendMessage("已完成!");
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        public DelegateCommand<ToDoDto> EditToDoCommand { get; private set; }
        public DelegateCommand<MemoDto> EditMemoCommand { get; private set; }
        public DelegateCommand<TaskBar> NavigateCommand { get; private set; }
        /// <summary>
        /// 首页点击待办/备忘录直接跳转到待办事项界面或备忘录界面
        /// </summary>
        /// <param name="obj"></param>

        private void Navigate(TaskBar obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Target)) return;

            NavigationParameters param = new NavigationParameters();

            //点击已完成，跳转到待办事项界面但只显示已完成的事项
            if (obj.Title == "已完成")
            {
                param.Add("Value", 2);
            }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.Target, param);
        }


        ////代办事项的数据集合
        //private ObservableCollection<ToDoDto> toDoDtos;

        //public ObservableCollection<ToDoDto> ToDoDtos
        //{
        //    get { return toDoDtos; }
        //    set { toDoDtos = value; RaisePropertyChanged(); }
        //}
        ////备忘录的数据集合
        //private ObservableCollection<Shared.Dtos.MemoDto> memoDtos;

        //public ObservableCollection<Shared.Dtos.MemoDto> MemoDtos
        //{
        //    get { return memoDtos; }
        //    set { memoDtos = value; RaisePropertyChanged(); }
        //}

        //初始化数据
        //public void CreateTestData()
        //{

        //    for (int i = 0; i < 10; i++)
        //    {
        //        ToDoDtos.Add(new ToDoDto() {Title="待办"+i,Content="正在处理..." });

        //        MemoDtos.Add(new Shared.Dtos.MemoDto() {Title="备忘"+i,Content="密码是..." });
        //    }

        //}

        /// <summary>
        /// 在主页点击新增区新增待办、备忘录
        /// </summary>
        public DelegateCommand<string> ExecuteCommand { get; private set; }
        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增待办": AddToDo(null); break;
                case "新增备忘录": AddMemo(null); break;
            }
        }

        //首页添加待办事项的弹窗
        async void AddToDo(ToDoDto model)
        {
            DialogParameters param = new DialogParameters();
            if (model != null)
                param.Add("Value", model);

            var dialogResult = await dialog.ShowDialog("AddToDoView",null);
            if (dialogResult.Result == ButtonResult.OK)
            {
                try
                {
                    UpdateLoading(true);
                    var todo = dialogResult.Parameters.GetValue<ToDoDto>("Value");
                    if (todo.Id > 0)
                    {
                        //修改
                        var updateResult = await toDoService.UpdateAsync(todo);
                        if (updateResult.Status)
                        {
                            var todoModel = summary.MemoList.FirstOrDefault(t => t.Id.Equals(todo.Id));
                            if (todoModel != null)
                            {
                                todoModel.Title = todo.Title;
                                todoModel.Content = todo.Content;
                            }
                        }
                    }
                    else
                    {
                        //新增
                        var addResult = await toDoService.AddAsync(todo);
                        if (addResult.Status)
                        {
                            summary.Sum += 1;
                            summary.ToDoList.Add(addResult.Result);
                            summary.CompletedRatio = (summary.CompletedCount / (double)summary.Sum).ToString("0%");
                            this.Refresh();
                        }


                    }

                }
                
                finally
                {
                    UpdateLoading(false);
                }
                
            }
        }
        //首页添加备忘录的弹窗
        async void AddMemo(MemoDto model)
        {
            DialogParameters param = new DialogParameters();
            if (model != null)
                param.Add("Value", model);

            var dialogResult = await dialog.ShowDialog("AddMemoView",null);
            
            if (dialogResult.Result == ButtonResult.OK)
            {
                try
                {
                    UpdateLoading(true);
                    var memo = dialogResult.Parameters.GetValue<MemoDto>("Value");
                    if (memo.Id > 0)
                    {
                        //修改
                        var updateResult = await memoService.UpdateAsync(memo);
                        if (updateResult.Status)
                        {
                            var todoModel = summary.MemoList.FirstOrDefault(t => t.Id.Equals(memo.Id));
                            if (todoModel != null)
                            {
                                todoModel.Title = memo.Title;
                                todoModel.Content = memo.Content;
                            }
                        }

                    }
                    else
                    {
                        //新增
                        var addResult = await memoService.AddAsync(memo);
                        if (addResult.Status)
                        {
                            summary.MemoList.Add(addResult.Result);
                            summary.MemoeCount += 1;
                            this.Refresh();
                        }


                    }
                }
               
                finally
                {
                    UpdateLoading(false);
                }
                
            }
        }

        //备忘录的数据集合
        private SummaryDto summary;

        public SummaryDto Summary
        {
            get { return summary; }
            set { summary = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 调用汇总接口，记录当前待办事项和备忘录的完成情况
        /// </summary>
        /// <param name="navigationContext"></param>
        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var summaryResult = await toDoService.SummaryAsync();
            if (summaryResult.Status)
            {
                Summary = summaryResult.Result;
                Refresh();
            }
            base.OnNavigatedTo(navigationContext);
        }

        /// <summary>
        /// 刷新首页记录待办事项和备忘录的完成情况
        /// </summary>
        void Refresh()
        {
            TaskBars[0].Content = summary.Sum.ToString();//待办事项
            TaskBars[1].Content = summary.CompletedCount.ToString();//完成数量
            TaskBars[2].Content = summary.CompletedRatio;//完成率
            TaskBars[3].Content = summary.MemoeCount.ToString();//备忘录数量
        }
    }
}
