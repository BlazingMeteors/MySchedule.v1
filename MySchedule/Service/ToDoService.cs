
using MySchedule.Shared.Dtos;
using MySchedule.Shared.QueryParams;
using MyToDo.Shared.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.Service
{
    //待办事项的服务
    public class ToDoService : BaseService<ToDoDto>, IToDoService
    {
        public ToDoService(HttpRestClient client, string serviceName) : base(client, "ToDo")
        {

        }

        
    }

}
