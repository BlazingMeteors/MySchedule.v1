using MySchedule.Common;
using MySchedule.Common.Events;
using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.Extensions
{
    //界面加载时的弹窗提示等待
    public static class DialogExtensions
    {
        /// <summary>
        /// 推送等待消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="model"></param>
        public static void UpdateLoading(this IEventAggregator aggregator,UpdateModel model)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Publish(model);
        }

        /// <summary>
        /// 注册等待加载的提示
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="model"></param>
        public static void Register(this IEventAggregator aggregator, Action<UpdateModel> model)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(model);
        }


        /// <summary>
        /// 询问窗口,扩展方法
        /// </summary>
        /// <param name="dialogHost">指定的DialogHost会话主机</param>
        /// <param name="title">标题</param>
        /// <param name="content">询问内容</param>
        /// <param name="dialogHostName">会话主机名称(唯一)</param>
        /// <returns></returns>
        public static async Task<IDialogResult> Question(this IDialogHostService dialogHost,
            string title, string content, string dialogHostName = "Root"
            )
        {
            DialogParameters param = new DialogParameters();
            param.Add("Title", title);
            param.Add("Content", content);
            param.Add("dialogHostName", dialogHostName);
            var dialogResult = await dialogHost.ShowDialog("MsgView", param, dialogHostName);
            return dialogResult;
        }

    }
}
