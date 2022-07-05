using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.Common
{
    /// <summary>
    /// 首页弹窗的添加待办和备忘录的接口
    /// </summary>
    public interface IDialogHostService:IDialogService
    {

        Task<IDialogResult> ShowDialog(string name, IDialogParameters parameters, string dialogHostName = "Root");

    }
}
