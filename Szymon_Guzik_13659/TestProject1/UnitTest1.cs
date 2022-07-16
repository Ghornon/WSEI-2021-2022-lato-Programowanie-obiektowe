using Microsoft.VisualStudio.TestTools.UnitTesting;
using Szymon_Guzik_13659.Tasks;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            object a = new PriorityTask("Task 1", 1);
            object b = new PriorityTask("Task 1", 1);
            object c = new DescribedTask("Task 2", 2, "Description 2");

            Assert.AreEqual(a, a);
            Assert.AreEqual(a, b);
            Assert.AreNotEqual(c, a);

            //TODO: zaproponuj asercje dla porównania c z b
            Assert.AreNotEqual(c, b);
            Assert.AreNotSame(c, b);

            //TODO: zaproponuj asercje dla porównania b z c
            Assert.AreNotEqual(b, c);
            Assert.AreNotSame(b, c);
        }
    }
}
