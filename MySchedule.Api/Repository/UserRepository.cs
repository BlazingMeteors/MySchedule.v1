using MySchedule.Api.Context;
using MyToDo.Api;

namespace MySchedule.Api.Repository
{




    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(MyScheduleContext dbContext) : base(dbContext)
        {

        }
    }
}
