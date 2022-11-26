using EvitelLib.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EvitelLib.Entity.State x = new EvitelLib.Entity.State();
            CLoginManipulation lu = new CLoginManipulation();
            lu.GetNoLoginUser();
        }
    }
}
