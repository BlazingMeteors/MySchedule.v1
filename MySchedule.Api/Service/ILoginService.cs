using MySchedule.Shared.Dtos;
using System.Threading.Tasks;

namespace MySchedule.Api.Service
{
    public interface ILoginService
    {

        Task<ApiResponse> LoginAsync(string Account, string Password);

        Task<ApiResponse> Resgiter(UserDto user);

    }
}
