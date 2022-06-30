using MySchedule.Shared.QueryParams;
using MyToDo.Shared.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedule.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly HttpRestClient client;
        //提供服务的名称
        private readonly string serviceName;

        public BaseService(HttpRestClient client, string serviceName)
        {
            this.client = client;
            this.serviceName = serviceName;
        }



        //增删改查
        async Task<ApiResponse<TEntity>> IBaseService<TEntity>.AddAsync(TEntity entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.POST;
            request.Route = $"api/{serviceName}/Add";
            request.Parameter = entity;
            return await client.ExecuteAsync<TEntity>(request);
        }

        async Task<ApiResponse> IBaseService<TEntity>.DeleteAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.DELETE;
            request.Route = $"api/{serviceName}/Delete?id={id}";
            return await client.ExecuteAsync(request);
        }

        async Task<ApiResponse<PagedList<TEntity>>> IBaseService<TEntity>.GetAllAsync(QueryParameters parameter)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.GET;
            request.Route = $"api/{serviceName}/GetAll?pageIndex={parameter.PageIndex}" +
                $"&pageSize={parameter.PageSize}" +
                $"&search={parameter.Search}";
            return await client.ExecuteAsync<PagedList<TEntity>>(request);
        }

        async Task<ApiResponse<TEntity>> IBaseService<TEntity>.GetFirstOfDefaultAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.GET;
            request.Route = $"api/{serviceName}/Get?id={id}";
            return await client.ExecuteAsync<TEntity>(request);
        }

        async Task<ApiResponse<TEntity>> IBaseService<TEntity>.UpdateAsync(TEntity entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.POST;
            request.Route = $"api/{serviceName}/Update";
            request.Parameter = entity;
            return await client.ExecuteAsync<TEntity>(request);
        }
    }
}
