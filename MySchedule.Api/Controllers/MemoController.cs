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
    public class MemoController:ControllerBase
    {
        private readonly IMemoService memoService;
        public MemoController(IMemoService memoService)
        {
            this.memoService = memoService;
        }

        //增删该
        [HttpGet]
        public async Task<ApiResponse> Get(int id)
        {
            return await memoService.GetSingleAsync(id);
        }

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery]QueryParameters parameters)
        {
            return await memoService.GetAllAsync(parameters);
        }

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody]MemoDto model)
        {
            return await memoService.AddAsync(model);
        }


        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] MemoDto model)
        {
            return await memoService.UpdateAsync(model);
        }

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id)
        {
            return await memoService.DeleteAsync(id);

        }

    }
}
