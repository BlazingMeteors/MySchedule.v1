using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.Shared.QueryParams
{
    public class QueryParameters
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

    }
}
