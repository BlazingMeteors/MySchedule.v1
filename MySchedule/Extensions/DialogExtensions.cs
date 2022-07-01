using MySchedule.Common.Events;
using Prism.Events;
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

    }
}
