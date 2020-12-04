using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Component_I;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var form = new Circle();
            
            var a = form.s;
            var b = form.n;
            var c = form.j;
            form.saved_values(1, 2, 3);
            bool test = false;
            if (a != form.s && b != form.n && c != form.j)
                test = true;
            Assert.IsTrue(test);
        }
    }
}
