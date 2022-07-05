
//using MySchedule.Common.Models;
using MySchedule.Common;
using MySchedule.Extensions;
using MySchedule.Service;
using MySchedule.Shared.Dtos;
using Prism.Commands;
using Prism.Ioc;
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
    public  class ToDoViewModel : NavigationViewModel
    {
        private readonly IDialogHostService dialogHost;
        public ToDoViewModel(IToDoService service,IContainerProvider containerProvider):base(containerProvider)
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<ToDoDto>(Selected);
            DeleteCommand = new DelegateCommand<ToDoDto>(Delete);
            dialogHost = containerProvider.Resolve<IDialogHostService>();
            this.service = service;
        }

        //待办事项服务
        private readonly IToDoService service;
        //待办事项的数据集合
        private ObservableCollection<ToDoDto> toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        //执行的操作
        public DelegateCommand<string> ExecuteCommand { get; private set; }
        //选中
        public DelegateCommand<ToDoDto> SelectedCommand { get; private set; }
        public DelegateCommand<ToDoDto> DeleteCommand { get; private set; }

        //点击添加待办事项，是否展开右侧的菜单栏
        private bool isRightDrawerOpen;
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 当前编辑选中的待办事项对象
        /// </summary>
        private ToDoDto currentDto;

        public ToDoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 待办事项的状态：下拉列表的选中值：待办/已完成
        /// </summary>
        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 搜索待办事项
        /// </summary>
        private string search;

        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }
        
        /// <summary>
        /// 根据不同的命令指令进行操作
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增":Add();break;
                case "查询":GetDataAsync();break;
                case "保存": Save(); break;
            }
        }

        private async void Save()
        {
            if (string.IsNullOrWhiteSpace(CurrentDto.Title) ||
               string.IsNullOrWhiteSpace(CurrentDto.Content))
                return;

            UpdateLoading(true);

            try
            {
                if (CurrentDto.Id > 0)
                {
                    //修改
                    var updateResult = await service.UpdateAsync(CurrentDto);
                    if (updateResult.Status)
                    {
                        var todo = ToDoDtos.FirstOrDefault(t => t.Id == CurrentDto.Id);
                        if (todo != null)
                        {
                            todo.Title = CurrentDto.Title;
                            todo.Content = CurrentDto.Content;
                            todo.Status = CurrentDto.Status;
                        }
                    }
                    IsRightDrawerOpen = false;
                }
                else
                {
                    //新增
                    var addResult = await service.AddAsync(CurrentDto);
                    if (addResult.Status)
                    {
                        ToDoDtos.Add(addResult.Result);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                UpdateLoading(false);
            }
        }

        //查询
        async void GetDataAsync()
        {
            UpdateLoading(true);
            //待办事项状态
            int? Status = SelectedIndex == 0 ? null : SelectedIndex == 2 ? 1 : 0;
            var todoResult = await service.GetAllAsync(new Shared.QueryParams.ToDoParameters()
            {
                PageIndex = 0,
                PageSize = 100,
                Search = search,
                Status = Status,

            });
            if (todoResult.Status)
            {
                ToDoDtos.Clear();
                foreach (var item in todoResult.Result.Items)
                {
                    ToDoDtos.Add(item);
                }
            }
            UpdateLoading(false);
        }

        //导航加载数据
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            if (navigationContext.Parameters.ContainsKey("Value"))
                SelectedIndex = navigationContext.Parameters.GetValue<int>("Value");
            else
                SelectedIndex = 0;
            GetDataAsync();
        }
        /// <summary>
        /// 点击添加待办事项按钮后，右侧弹窗是否打开
        /// </summary>
        void Add()
        {
            //添加时要new一下实例
            CurrentDto = new ToDoDto();
            IsRightDrawerOpen = true;
        }
        /// <summary>
        /// 选中待办事项后，展开右侧菜单栏
        /// </summary>
        /// <param name="obj"></param>
        private async void Selected(ToDoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var toDoResult = await service.GetFirstOfDefaultAsync(obj.Id);
                if (toDoResult.Status)
                {
                    CurrentDto = toDoResult.Result;
                    isRightDrawerOpen = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                UpdateLoading(false);
            }


        }
        private async void Delete(ToDoDto obj)
        {
            try
            {
                var dialogResult = await dialogHost.Question("温馨提示", $"确认删除待办事项:{obj.Title} ?");
                if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;

                UpdateLoading(true);
                var deleteResult = await service.DeleteAsync(obj.Id);
                if (deleteResult.Status)
                {
                    var model = ToDoDtos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (model != null)
                        ToDoDtos.Remove(model);
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

    }
}
