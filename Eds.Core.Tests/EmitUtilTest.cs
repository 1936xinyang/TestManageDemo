using System;
using System.Reflection;
using Eds.Core.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eds.Core.Tests
{
    [TestClass]
    public class EmitUtilTest
    {
        [TestMethod]
        public void GetPropertyGetterTest()
        {
            UserInfo user = new UserInfo() {ID= 1,UserName="Martin", Age=30};
            object oo = user;
            PropertyInfo p = user.GetType().GetProperty("UserName");
            object o = EmitUtil.GetPropertyGetter(p).Invoke(oo);
        }

        private class UserInfo
        {
            public int ID { get; set; }
            public string UserName { get; set; }
            public int Age { get; set; }
        }
    }
}
