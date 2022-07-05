﻿using AutoMapper;
using MySchedule.Api.Context;
using MySchedule.Shared.Dtos;
using MySchedule.Shared.QueryParams;
using MyToDo.Api;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MySchedule.Api.Service
{
    /// <summary>
    /// 待办事项的接口实现
    /// </summary>
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper Mapper;

        //private readonly IMapper Mapper;
        public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            Mapper = mapper;
        }

        //增删改查
        public async Task<ApiResponse> AddAsync(ToDoDto model)
        {
            try
            {
                //数据传输层与数据库实体层之间的转换
                var todo = Mapper.Map<ToDo>(model);

                await unitOfWork.GetRepository<ToDo>().InsertAsync(todo);
                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, todo);
                return new ApiResponse("添加数据失败");
            }catch(Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository
                    .GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                repository.Delete(todo);

                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, "");
                return new ApiResponse("删除数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(QueryParameters parameter)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todos = await repository.GetPagedListAsync(predicate:
                   x => string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search),
                   pageIndex: parameter.PageIndex,
                   pageSize: parameter.PageSize,
                   orderBy: source => source.OrderByDescending(t => t.CreateDate));
                return new ApiResponse(true, todos);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(ToDoParameters parameter)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todos = await repository.GetPagedListAsync(predicate:
                   x => (string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search))
                   && (parameter.Status == null ? true : x.Status.Equals(parameter.Status)),
                   pageIndex: parameter.PageIndex,
                   pageSize: parameter.PageSize,
                   orderBy: source => source.OrderByDescending(t => t.CreateDate));
                return new ApiResponse(true, todos);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate:x=>x.Id.Equals(id));
                return new ApiResponse(true, todo);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> Summary()
        {
            //try
            //{
            //    //待办事项结果
            //    var todos = await unitOfWork.GetRepository<ToDo>().GetAllAsync(
            //        orderBy: source => source.OrderByDescending(t => t.CreateDate));

            //    //备忘录结果
            //    var memos = await work.GetRepository<Memo>().GetAllAsync(
            //        orderBy: source => source.OrderByDescending(t => t.CreateDate));

            //    SummaryDto summary = new SummaryDto();
            //    summary.Sum = todos.Count(); //汇总待办事项数量
            //    summary.CompletedCount = todos.Where(t => t.Status == 1).Count(); //统计完成数量
            //    summary.CompletedRatio = (summary.CompletedCount / (double)summary.Sum).ToString("0%"); //统计完成率
            //    summary.MemoeCount = memos.Count();  //汇总备忘录数量
            //    summary.ToDoList = new ObservableCollection<ToDoDto>(Mapper.Map<List<ToDoDto>>(todos.Where(t => t.Status == 0)));
            //    summary.MemoList = new ObservableCollection<MemoDto>(Mapper.Map<List<MemoDto>>(memos));

            //    return new ApiResponse(true, summary);
            //}
            //catch (Exception ex)
            //{
            //    return new ApiResponse(false, "");
            //}
            return new ApiResponse(false, "");
        }


        //更新
        public async Task<ApiResponse> UpdateAsync(ToDoDto model)
        {
            try
            {
                var dbToDo = Mapper.Map<ToDo>(model);
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(dbToDo.Id));

                todo.Title = dbToDo.Title;
                todo.Content = dbToDo.Content;
                todo.Status = dbToDo.Status;
                todo.UpdateDate = DateTime.Now;

                repository.Update(todo);

                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, todo);
                return new ApiResponse("更新数据异常！");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }


    }
}
