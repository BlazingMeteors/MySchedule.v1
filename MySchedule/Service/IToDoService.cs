
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
    public interface IToDoService:IBaseService<ToDoDto>
{
        //Task<ApiResponse<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameters parameter);

        //Task<ApiResponse<SummaryDto>> SummaryAsync();
    }
}
