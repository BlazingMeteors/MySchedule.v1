namespace MySchedule.Api.Service
{
    //通用类
    public class ApiResponse
    {
        //添加失败，提示错误消息
        public ApiResponse(string message, bool status = false)
        {
            this.Message = message;
            this.Status = status;
        }

        //
        public ApiResponse(bool status, object result)
        {
            this.Status = status;
            this.Result = result;
        }

        //基本属性
        public string Message { get; set; }

        public bool Status { get; set; }

        public object Result { get; set; }


    }
}
