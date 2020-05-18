using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class BooleansTests : BaseTests
    {

        private static bool F => false;
        private static bool T => true;
        private static string Fs => "False";
        private static string Ts => "True";

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(Booleans);
        }

        [TestMethod]
        public void ToBooleanTest()
        {
            Assert.AreEqual(F, Booleans.ToBoolean(null));
            Assert.AreEqual(F, Booleans.ToBoolean(GetRandom.String()));
            Assert.AreEqual(F, Booleans.ToBoolean(F.ToString()));
            Assert.AreEqual(T, Booleans.ToBoolean(T.ToString()));
            Assert.AreEqual(F, Booleans.ToBoolean("f"));
            Assert.AreEqual(T, Booleans.ToBoolean("t"));
            Assert.AreEqual(F, Booleans.ToBoolean("no"));
            Assert.AreEqual(T, Booleans.ToBoolean("yes"));
            Assert.AreEqual(F, Booleans.ToBoolean("n"));
            Assert.AreEqual(T, Booleans.ToBoolean("y"));
        }

        [TestMethod]
        public void ToBooleanStringTest()
        {
            Assert.AreEqual(null, Booleans.ToBooleanString(null));
            var s = GetRandom.String();
            Assert.AreEqual(s, Booleans.ToBooleanString(s));
            Assert.AreEqual(Fs, Booleans.ToBooleanString(F.ToString()));
            Assert.AreEqual(Ts, Booleans.ToBooleanString(T.ToString()));
            Assert.AreEqual(Fs, Booleans.ToBooleanString("f"));
            Assert.AreEqual(Ts, Booleans.ToBooleanString("t"));
            Assert.AreEqual(Fs, Booleans.ToBooleanString("no"));
            Assert.AreEqual(Ts, Booleans.ToBooleanString("yes"));
            Assert.AreEqual(Fs, Booleans.ToBooleanString("n"));
            Assert.AreEqual(Ts, Booleans.ToBooleanString("y"));
        }

        [TestMethod]
        public void IsFalseStringTest()
        {
            Assert.AreEqual(F, Booleans.IsFalseString(null));
            Assert.AreEqual(F, Booleans.IsFalseString(GetRandom.String()));
            Assert.AreEqual(T, Booleans.IsFalseString(F.ToString()));
            Assert.AreEqual(F, Booleans.IsFalseString(T.ToString()));
            Assert.AreEqual(T, Booleans.IsFalseString("f"));
            Assert.AreEqual(F, Booleans.IsFalseString("t"));
            Assert.AreEqual(T, Booleans.IsFalseString("no"));
            Assert.AreEqual(F, Booleans.IsFalseString("yes"));
            Assert.AreEqual(T, Booleans.IsFalseString("n"));
            Assert.AreEqual(F, Booleans.IsFalseString("y"));
        }

        [TestMethod]
        public void IsTrueStringTest()
        {
            Assert.AreEqual(false, Booleans.IsTrueString(null));
            Assert.AreEqual(false, Booleans.IsTrueString(GetRandom.String()));
            Assert.AreEqual(false, Booleans.IsTrueString(false.ToString()));
            Assert.AreEqual(true, Booleans.IsTrueString(true.ToString()));
            Assert.AreEqual(false, Booleans.IsTrueString("f"));
            Assert.AreEqual(true, Booleans.IsTrueString("t"));
            Assert.AreEqual(false, Booleans.IsTrueString("no"));
            Assert.AreEqual(true, Booleans.IsTrueString("yes"));
            Assert.AreEqual(false, Booleans.IsTrueString("n"));
            Assert.AreEqual(true, Booleans.IsTrueString("y"));
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("True", Booleans.ToString(true));
            Assert.AreEqual("False", Booleans.ToString(false));
        }

        [TestMethod]
        public void AndTest()
        {
            Assert.AreEqual(true, true.And(true));
            Assert.AreEqual(false, false.And(true));
            Assert.AreEqual(false, true.And(false));
            Assert.AreEqual(false, false.And(false));
        }

        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(true.Or(true), true.Add(true));
            Assert.AreEqual(false.Or(true), false.Add(true));
            Assert.AreEqual(true.Or(false), true.Add(false));
            Assert.AreEqual(false.Or(false), false.Add(false));
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Assert.AreEqual(true.And(true), true.Multiply(true));
            Assert.AreEqual(false.And(true), false.Multiply(true));
            Assert.AreEqual(true.And(false), true.Multiply(false));
            Assert.AreEqual(false.And(false), false.Multiply(false));
        }

        [TestMethod]
        public void OrTest()
        {
            Assert.AreEqual(true, true.Or(true));
            Assert.AreEqual(true, false.Or(true));
            Assert.AreEqual(true, true.Or(false));
            Assert.AreEqual(false, false.Or(false));
        }

        [TestMethod]
        public void XorTest()
        {
            Assert.AreEqual(false, true.Xor(true));
            Assert.AreEqual(true, false.Xor(true));
            Assert.AreEqual(true, true.Xor(false));
            Assert.AreEqual(false, false.Xor(false));
        }

        [TestMethod]
        public void NotTest()
        {
            Assert.AreEqual(false, true.Not());
            Assert.AreEqual(true, false.Not());
        }

    }

}
