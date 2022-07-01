using AutoMapper;
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
    /// 备忘录的接口实现
    /// </summary>
    public class MemoService : IMemoService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper Mapper;

        //private readonly IMapper Mapper;
        public MemoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            Mapper = mapper;
        }

        //增删改查
        //public async Task<ApiResponse> AddAsync(MemoDto model)
        //{
        //    try
        //    {
        //        //数据传输层与数据库实体层之间的转换
        //        var memo = Mapper.Map<Memo>(model);

        //        await unitOfWork.GetRepository<Memo>().InsertAsync(memo);
        //        if (await unitOfWork.SaveChangesAsync() > 0)
        //            return new ApiResponse(true, memo);
        //        return new ApiResponse("添加数据失败");
        //    }
        //    catch(Exception ex)
        //    {
        //        return new ApiResponse(ex.Message);
        //    }
        //}
        public async Task<ApiResponse> AddAsync(MemoDto model)
        {
            try
            {
                //数据传输层与数据库实体层之间的转换
                var memo = Mapper.Map<Memo>(model);

                await unitOfWork.GetRepository<Memo>().InsertAsync(memo);
                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, memo);
                return new ApiResponse("添加数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<Memo>();
                var memo = await repository
                    .GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                repository.Delete(memo);

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
                var repository = unitOfWork.GetRepository<Memo>();
                var memos = await repository.GetPagedListAsync(predicate:
                   x => string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search),
                   pageIndex: parameter.PageIndex,
                   pageSize: parameter.PageSize,
                   orderBy: source => source.OrderByDescending(t => t.CreateDate));
                return new ApiResponse(true, memos);
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
                var repository = unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate:x=>x.Id.Equals(id));
                return new ApiResponse(true, memo);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }


        //更新
        public async Task<ApiResponse> UpdateAsync(MemoDto model)
        {
            try
            {
                var dbMemo = Mapper.Map<Memo>(model);
                var repository = unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(dbMemo.Id));

                memo.Title = dbMemo.Title;
                memo.Content = dbMemo.Content;
                memo.UpdateDate = DateTime.Now;

                repository.Update(memo);

                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, memo);
                return new ApiResponse("更新数据异常！");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }


    }
}
