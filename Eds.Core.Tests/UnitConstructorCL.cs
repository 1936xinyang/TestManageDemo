using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Eds.Core.Tests.Cases.ConstructorCL;

namespace Eds.Core.Tests
{
    [TestClass]
    public class UnitConstructorCL
    {
        [TestMethod]
        public void TestMethod1()
        {

            double d = 1.6;
            int i = (int)d;
            ItemClass cl = new ItemClass("ty");
            
        }
    }
}
