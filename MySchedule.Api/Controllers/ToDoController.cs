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
    /// 待办事项的控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoController:ControllerBase
    {
        private readonly IToDoService toDoService;
        public ToDoController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        //增删改查
        [HttpGet]
        public async Task<ApiResponse> Get(int id)
        {
            return await toDoService.GetSingleAsync(id);
        }

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery]QueryParameters parameters)
        {
            return await toDoService.GetAllAsync(parameters);
        }

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody]ToDoDto model)
        {
            return await toDoService.AddAsync(model);
        }
        

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] ToDoDto model)
        {
            return await toDoService.UpdateAsync(model);
        }

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id)
        {
            return await toDoService.DeleteAsync(id);

        }

    }
}
