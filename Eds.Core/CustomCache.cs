using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eds.Core
{
    public class CustomCache
    {
        /// <summary>
        /// 保证常驻内存，不会被GC(全局唯一的，是共享的)
        /// Dictionary 保存多项（List不合适，是数组 不适合更新）
        /// private私有化，数据要安全
        /// </summary>
        private static Dictionary<string, object> CustomCacheDicTionary = new Dictionary<string, object>();

        public static void Save(string key,object oValue)
        {
            CustomCacheDicTionary.Add(key,oValue);
        }
        public static T Get<T>(string key)
        {
            return (T)CustomCacheDicTionary[key];
        }
        public static void  Remove(string key)
        {
             CustomCacheDicTionary.Remove(key);
        }
        public static void RemoveAll()
        {
             CustomCacheDicTionary.Clear();
        }
        public static void RemoveCondition(Func<string,bool> func)
        {
            List<string> keyList = new List<string>();
            foreach (var key in CustomCacheDicTionary.Keys)
            {
                if (func.Invoke(key))
                {
                    keyList.Add(key);
                }
            }
            keyList.ForEach(k=>CustomCacheDicTionary.Remove(k));
        }
        public static T GetData<T>(string key,Func<T> func)
        {
            T tResult = default(T);
            if (!CustomCache.Exist(key))
            {
            }
            else
            {
                tResult = CustomCache.Get<T>(key);
            }
            return tResult;
        }

        private static bool Exist(string key)
        {
            throw new NotImplementedException();
        }
    }
}
