using Microsoft.EntityFrameworkCore;
using MySchedule.Api.Context;
using MySchedule.Shared.Dtos;
using MyToDo.Api;
using System.Threading.Tasks;

namespace MySchedule.Api.Repository
{
    //使用UnitWork
    //ToDo日程记录的仓储
    public class ToDoRepository : Repository<ToDo>, IRepository<ToDo>
    {
        public ToDoRepository(MyScheduleContext dbContext) : base(dbContext)
        {

        }
    }

}
