using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Helper;

namespace WebApi.Controllers
{
    [RoutePrefix("api/order")] //同一个控制器的所有的action的所有特性路由标识一个相同的前缀，这种做法并非必须，但这样能够增加url的可读性。
    public class OrderController : ApiController
    {
        [HttpGet]
        public object GetAll()
        {
            return "Success";
        }

        [ActionName("TestApi")]  //如果你想要方法名和action的名称不一致，你也可以自定义action的名称，这个可以通过特性ActionName来实现
        [Route("{id:int=3}/OrderDetailById")]  //使用“{}”占位符动态传递参数,参数约束:这里约束可变部分{id}的取值必须是int类型。并且默认值是3.
        [HttpGet]
        public object GetById(int id)
        {
            return "Success" + id;
        }

        [HttpGet]
        public async Task<string> Get(string str)
        {
            GetDataHelper sqlHelper = new GetDataHelper();
            switch (str)
            {
                case "异步处理"://
                    return await sqlHelper.GetDataAsync();
                case "同步处理"://
                    return sqlHelper.GetData();
            }
            return "参数不正确";
        }       
    }
}
