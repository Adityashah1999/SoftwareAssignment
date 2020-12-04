using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Component_I;

namespace UnitTest
{
    [TestClass]
    public class pentomove
    {
        [TestMethod]
        public void TestMethod1()
        {
            var form = new Form1();
            var a = form.positionXaxis;
            var b = form.positionYaxis;
            form.pentomove(10, 20);
            bool eql = false;
            if (a != form.positionXaxis && b != form.positionYaxis)
                eql = true;
            Assert.IsTrue(eql);
        }
    }
}
