using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Component 

namespace Unit__Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var form = new Form1();
            var a = form.XaxisPosition;
            var b = form.YaxisPosition;
            form.pentomov(10, 10);
            bool ex = false;
            if (a != form.XaxisPosition && b != form.YaxisPosition)
                ex = true;
            Assert.IsTrue(ex);
        }
    }
}
