using System;
using Eds.Core.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eds.Core.Tests
{
    [TestClass]
    public class UnitArrayUtil
    {
        [TestMethod]
        public void TestMethod1()
        {
            ArrayUtil ul = new ArrayUtil();
            ul.FindData(2);
        }
    }
}
