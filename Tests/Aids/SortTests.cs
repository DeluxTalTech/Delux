using System;
using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateTime = System.DateTime;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class SortTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(Sort);
        }

        [TestMethod]
        public void AscendingTest()
        {
            SortAscendingTest(DateTime.MaxValue, DateTime.MinValue);
            SortAscendingTest(double.MaxValue, double.MinValue);
            SortAscendingTest(int.MaxValue, int.MinValue);
        }

        private static void SortAscendingTest<T>(T max, T min) where T : IComparable
        {
            Assert.IsTrue(max.CompareTo(min) >= 0);
            Sort.Ascending(ref max, ref min);
            Assert.IsTrue(max.CompareTo(min) <= 0);
        }
        [TestMethod]
        public void DescendingTest()
        {
            SortDescendingTest(DateTime.MinValue, DateTime.MaxValue);
            SortDescendingTest(double.MinValue, double.MaxValue);
            SortDescendingTest(int.MinValue, int.MaxValue);
        }

        private static void SortDescendingTest<T>(T min, T max) where T : IComparable
        {
            Assert.IsTrue(min.CompareTo(max) <= 0);
            Sort.Descending(ref min, ref max);
            Assert.IsTrue(min.CompareTo(max) >= 0);
        }
    }
}
