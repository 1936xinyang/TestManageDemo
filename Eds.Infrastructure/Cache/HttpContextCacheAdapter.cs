using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Eds.Infrastructure.Cache
{
    /// <summary>
    /// HttpContext缓存的包装器，HttpContextCacheAdapter包装了HttpContext.Current.Cache实例，并在实现ICacheStorage接口契约时将工作委托给它。
    /// </summary>
    public class HttpContextCacheAdapter : ICacheStorage
    {
        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public void Store(string key, object data)
        {
            HttpContext.Current.Cache.Insert(key, data);
        }

        public T Retrieve<T>(string key)
        {
            T itemStored = (T)HttpContext.Current.Cache.Get(key);
            if (itemStored == null)
                itemStored = default(T);

            return itemStored;
        }
    }
}
