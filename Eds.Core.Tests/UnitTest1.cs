using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eds.Core.Utils;

namespace Eds.Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodConcat()
        {
            string[] strings = new[] { "to", "be", "or", "not", "to", "be" };
            Assert.AreEqual("totobetoortonottototobe", strings.Concat("to"));
            Assert.AreEqual("totobetoortonottototobe", StringUtil.Concat(strings, "to"));
        }
    }
}
