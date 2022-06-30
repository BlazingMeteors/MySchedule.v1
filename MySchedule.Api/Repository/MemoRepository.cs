using Microsoft.EntityFrameworkCore;
using MySchedule.Api.Context;
using MyToDo.Api;

namespace MySchedule.Api.Repository
{
    //备忘录数据的仓储
    public class MemoRepository : Repository<Memo>, IRepository<Memo>
    {
        public MemoRepository(MyScheduleContext dbContext) : base(dbContext)
        {

        }
    }
}
