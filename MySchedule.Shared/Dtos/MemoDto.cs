using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.Shared.Dtos
{
    /// <summary>
    /// 备忘录的实体类：作为控制器传输的层
    /// </summary>
    public class MemoDto:BaseDto
    {


        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; OnPropertyChanged(); }
        }

        //private int status;

        //public int Status
        //{
        //    get { return status; }
        //    set { status = value; OnPropertyChanged(); }
        //}





    }
}
