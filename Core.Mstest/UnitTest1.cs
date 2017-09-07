using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Mstest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestMethod2() 
        {
            Assert.IsTrue(1==2);
        }

    }
}
