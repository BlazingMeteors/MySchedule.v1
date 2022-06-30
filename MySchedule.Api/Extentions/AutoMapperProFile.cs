using AutoMapper;
using AutoMapper.Configuration;
using MySchedule.Api.Context;
using MySchedule.Shared.Dtos;

namespace MySchedule.Api.Extentions
{
    public class AutoMapperProFile:MapperConfigurationExpression
    {
        /// <summary>
        /// 数据传输层和数据库实体层之间的类型对应转换
        /// </summary>

        public AutoMapperProFile()
        {
            //自动转换
            CreateMap<ToDo, ToDoDto>().ReverseMap();

            CreateMap<Memo, MemoDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

        }


    }
}
