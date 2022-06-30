using Microsoft.EntityFrameworkCore;

namespace MySchedule.Api.Context
{
    public class MyScheduleContext:DbContext
    {
        public MyScheduleContext(DbContextOptions<MyScheduleContext>options):base(options)
        {

        }

        //添加数据表
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<Memo> Memo { get; set; }
        public DbSet<User> User { get; set; }


    }
}
