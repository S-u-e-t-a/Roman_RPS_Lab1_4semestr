using System.Collections.Generic;
using laba1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModule
{
    [TestClass]
    public class UnitTestLaba1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var numbers = new List<int> {0, 0, 0, 0, 0};
            double expected = 0;
            var actual = Algorithm.GetAverage(numbers).Average;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var numbers = new List<int> {-50, -40, -30, -20, 10};
            double expected = 30;
            var actual = Algorithm.GetAverage(numbers).Average;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var numbers = new List<int> {1};
            double expected = 1;
            var actual = Algorithm.GetAverage(numbers).Average;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var numbers = new List<int> {1, 2};
            var expected = 1.5;
            var actual = Algorithm.GetAverage(numbers).Average;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var numbers = new List<int> {200, 136, -28763};
            var expected = 9699.66667;
            var actual = Algorithm.GetAverage(numbers).Average;
            Assert.AreEqual(expected, actual);
        }
    }
}