using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eds.Core.Utils
{
    //拓展方法必须在非泛型静态类中定义
    public static class StringUtil
    {
        public static string Concat(this string[] strings, string separator)
        {
            bool first = true;
            var builder = new StringBuilder();
            foreach (var s in strings)
            {

                if (!first)
                    builder.Append(separator);
                else
                    first = false;
                builder.Append(s);
            }
            return builder.ToString();

        }
    }
}
