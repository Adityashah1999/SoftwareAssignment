using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Component_I;
namespace UnitTestRectangle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var form = new Rectangle();

            var a = form.s;
            var b = form.n;
            var c = form.j;
            var d = form.y;
            form.saved_values(1, 2, 3, 4);
            bool test = false;
            if (a != form.s && b != form.n && c != form.j && d != form.y)
                test = true;
            Assert.IsTrue(test);
        }
    }
}
