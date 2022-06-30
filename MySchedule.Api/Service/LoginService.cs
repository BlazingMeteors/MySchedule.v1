using AutoMapper;
using MySchedule.Api.Context;
using MySchedule.Shared.Dtos;
using MyToDo.Api;
using System;
using System.Threading.Tasks;

namespace MySchedule.Api.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper Mapper;

        //private readonly IMapper Mapper;
        public LoginService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<ApiResponse> LoginAsync(string Account, string Password)
        {
            try
            {
                var model = unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(predicate:
                    x => (x.Account.Equals(Account))&&
                    (x.PassWord.Equals(Password)));
                if (model == null)
                    return new ApiResponse("账号或密码错误,请重试！");

                return new ApiResponse(true, model);
            }
            catch (Exception ex)
            {

                return new ApiResponse(false, "登录失败");
            }
         
        }

        public async Task<ApiResponse> Resgiter(UserDto user)
        {
            try
            {
                var model = Mapper.Map<User>(user);
                var repository = unitOfWork.GetRepository<User>();
                var userModel = await repository.GetFirstOrDefaultAsync(predicate: x => x.Account.Equals(model.Account));

                if (userModel != null)
                    return new ApiResponse($"当前账号:{model.Account}已存在,请重新注册！");

                model.CreateDate = DateTime.Now;
                //model.PassWord = model.PassWord.GetMD5();
                await repository.InsertAsync(model);

                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, model);

                return new ApiResponse("注册失败,请稍后重试！");
            }
            catch (Exception ex)
            {
                return new ApiResponse("注册账号失败！");
            }
        }
    }
}
