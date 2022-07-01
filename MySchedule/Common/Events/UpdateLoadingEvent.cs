using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.Common.Events
{
    public class UpdateModel
    {
        //窗口是否处于打开状态
        public bool IsOpen { get;set; }
    }
    public class UpdateLoadingEvent:PubSubEvent<UpdateModel>
    {



    }
}
