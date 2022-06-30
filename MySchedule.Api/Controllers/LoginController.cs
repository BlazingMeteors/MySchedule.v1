using Microsoft.AspNetCore.Mvc;
using MySchedule.Api.Context;
using MySchedule.Api.Service;
using MySchedule.Shared.Dtos;
using MySchedule.Shared.QueryParams;
using MyToDo.Api;
using System.Threading.Tasks;

namespace MySchedule.Api.Controllers
{
    /// <summary>
    /// 备忘录的控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

 
        [HttpGet]
        public async Task<ApiResponse> LoginAsync(string account,string passward)
        {
            return await loginService.LoginAsync(account,passward);
        }

       
        [HttpPost]
        public async Task<ApiResponse> Register([FromBody]UserDto model)
        {
            return await loginService.Resgiter(model);
        }
        

      
    }
}
