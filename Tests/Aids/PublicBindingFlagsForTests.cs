using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class PublicBindingFlagsForTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(PublicBindingFlagsFor);
            _testType = typeof(TestClass);
        }

        private const BindingFlags P = BindingFlags.Public;
        private const BindingFlags I = BindingFlags.Instance;
        private const BindingFlags S = BindingFlags.Static;
        private const BindingFlags D = BindingFlags.DeclaredOnly;
        private Type _testType;

        internal class TestClass
        {
            public void Aaa() => Bbb();

            private void Bbb() { }

            public static void Ccc() => Ddd();

            private static void Ddd() { }
        }

        [TestMethod]
        public void AllMembersTest()
            => TestMembers(I | S | P, PublicBindingFlagsFor.AllMembers, 7);

        [TestMethod]
        public void InstanceMembersTest()
            => TestMembers(I | P, PublicBindingFlagsFor.InstanceMembers, 6);

        [TestMethod]
        public void StaticMembersTest()
            => TestMembers(S | P, PublicBindingFlagsFor.StaticMembers, 1);

        [TestMethod]
        public void DeclaredMembersTest()
            => TestMembers(D | I | S | P, PublicBindingFlagsFor.DeclaredMembers, 3);

        private void TestMembers(BindingFlags expected, BindingFlags actual,
            int membersCount)
        {
            var a = _testType.GetMembers(actual);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(membersCount, a.Length);
        }
    }
}
