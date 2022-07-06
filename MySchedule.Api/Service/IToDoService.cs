using MySchedule.Api.Context;
using MySchedule.Shared.Dtos;
using MySchedule.Shared.QueryParams;
using System.Threading.Tasks;

namespace MySchedule.Api.Service
{
    public interface IToDoService:IBaseService<ToDoDto>
    {
        Task<ApiResponse> GetAllAsync(ToDoParameters query);


        /// <summary>
        /// 首页汇总
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse> Summary();



    }
}
