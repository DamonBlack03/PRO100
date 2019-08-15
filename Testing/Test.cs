using BoardDisplay.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class MyTestClass
    {
        GameController controller;


        [TestMethod]
        public void MyTestMethod()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
