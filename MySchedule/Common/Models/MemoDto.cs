using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.Common.Models
{
    /// <summary>
    /// 备忘录实体类
    /// </summary>
    internal class MemoDto:BaseToDoBar
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
