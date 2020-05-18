using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class DecimalsTests : BaseTests
    {

        private decimal _d1;
        private decimal _absD1;
        private decimal _d2;
        private const decimal Min = decimal.MinValue;
        private const decimal Max = decimal.MaxValue;
        private const decimal Zero = decimal.Zero;

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(Decimals);
            _d1 = GetRandom.Decimal() / 2M;
            _d2 = GetRandom.Decimal() / 2M;
            _absD1 = System.Math.Abs(_d1);
        }

        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(_d1 + _d2, _d1.Add(_d2));
            Assert.AreEqual(0, (-_d1).Add(_d1));
            Assert.AreEqual(0, Min.Add(Max));
            Assert.AreEqual(Max, Max.Add(Max));
            Assert.AreEqual(Max, Min.Add(Min));
            Assert.AreEqual(Max, Max.Add(_absD1));
            Assert.AreEqual(Max - _absD1, Max.Add(-_absD1));
            Assert.AreEqual(Min + _absD1, Min.Add(_absD1));
            Assert.AreEqual(Max, Min.Add(-_absD1));
        }

        [TestMethod]
        public void DivideTest()
        {
            Assert.AreEqual(_d1 / _d2, _d1.Divide(_d2));
            Assert.AreEqual(0, Zero.Divide(_d1));
            Assert.AreEqual(Max, _d1.Divide(Zero));
        }

        [TestMethod]
        public void OppositeTest()
        {
            Assert.AreEqual(-_d1, _d1.Opposite());
            Assert.AreEqual(Min, Max.Opposite());
            Assert.AreEqual(Max, Min.Opposite());
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Assert.AreEqual(Zero, Zero.Multiply(_d1));
            Assert.AreEqual(Zero, _d1.Multiply(Zero));
            Assert.AreEqual(Max, _d1.Multiply(Max));
            Assert.AreEqual(Max, _d1.Multiply(Min));
            Assert.AreEqual(_d1 * 0.12345M, _d1.Multiply(0.12345M));
        }

        [TestMethod]
        public void InverseTest()
        {
            Assert.AreEqual(1 / _d1, _d1.Inverse());
            Assert.AreEqual(0, Max.Inverse());
            Assert.AreEqual(0, Min.Inverse());
            Assert.AreEqual(Max, Zero.Inverse());
        }

        [TestMethod]
        public void SubtractTest()
        {
            Assert.AreEqual(_d1 - _d2, _d1.Subtract(_d2));
            Assert.AreEqual(0, _d1.Subtract(_d1));
            Assert.AreEqual(0, Max.Subtract(Max));
            Assert.AreEqual(0, Min.Subtract(Min));
            Assert.AreEqual(Max, Min.Subtract(Max));
            Assert.AreEqual(Max, Max.Subtract(Min));
        }

        [TestMethod]
        public void SquareTest()
        {
            static void Test(decimal x)
            {
                Assert.AreEqual(x.Multiply(x), x.Square());
            }

            Test(_d1);
            Test(_d2);
            Test(Min);
            Test(Max);
        }

    }

}
