using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class IsReadOnlyTests : BaseTests
    {
        private class TestClass
        {
            public string A;
            public readonly string B = "";
            public TestClass() { E = ""; }
            public string C { get; set; }
            public string D { get; } = "";
            public string E { get; private set; }
        }
        private TestClass o;

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(IsReadOnly);
            o = new TestClass { A = "", C = "" };
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Assert.IsNotNull(o.A);
            Assert.IsNotNull(o.B);
            Assert.IsNotNull(o.C);
            Assert.IsNotNull(o.D);
            Assert.IsNotNull(o.E);
        }
        [TestMethod]
        public void FieldTest()
        {
            Assert.IsFalse(IsReadOnly.Field<TestClass>("A"));
            Assert.IsTrue(IsReadOnly.Field<TestClass>("B"));
            Assert.IsFalse(IsReadOnly.Field<TestClass>("C"));
            Assert.IsFalse(IsReadOnly.Field<TestClass>("D"));
            Assert.IsFalse(IsReadOnly.Field<TestClass>("E"));
        }
        [TestMethod]
        public void PropertyTest()
        {
            Assert.IsFalse(IsReadOnly.Property<TestClass>("A"));
            Assert.IsFalse(IsReadOnly.Property<TestClass>("B"));
            Assert.IsFalse(IsReadOnly.Property<TestClass>("C"));
            Assert.IsTrue(IsReadOnly.Property<TestClass>("D"));
            Assert.IsFalse(IsReadOnly.Property<TestClass>("E"));
        }
    }
}
