using MySchedule.Shared.QueryParams;
using System.Threading.Tasks;

namespace MySchedule.Api.Service
{
    //通用的接口：增删改查
    public interface IBaseService<T>
    {
        Task<ApiResponse> GetAllAsync(QueryParameters query);

        Task<ApiResponse> GetSingleAsync(int id);

        Task<ApiResponse> AddAsync(T model);

        Task<ApiResponse> UpdateAsync(T model);

        Task<ApiResponse> DeleteAsync(int id);



    }
}
