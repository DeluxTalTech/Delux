using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Delux.Aids;
using Delux.Facade.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class GetClassTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => Type = typeof(GetClass);

        [TestMethod]
        public void NamespaceTest()
        {
            var t = typeof(object);
            Assert.AreEqual(t.Namespace, GetClass.Namespace(t));
            Assert.AreEqual(string.Empty, GetClass.Namespace(null));
        }

        [TestMethod]
        public void MembersTest()
        {
            TestMember(typeof(TestClass));
            TestNull(null);
        }

        private static void TestNull(Type t)
        {
            var a = GetClass.Members(t);
            Assert.IsInstanceOfType(a, typeof(List<MemberInfo>));
            Assert.AreEqual(0, a.Count);
        }

        private static void TestMember(Type t)
        {
            var a = GetClass.Members(t, PublicBindingFlagsFor.AllMembers, false);
            var e = t.GetMembers(PublicBindingFlagsFor.AllMembers);
            Assert.AreEqual(e.Length, a.Count);
            Assert.AreEqual(10, a.Count);
            foreach (var v in e) Assert.IsTrue(a.Contains(v));
            Assert.AreEqual(7, GetClass.Members(t).Count);
        }

        [TestMethod]
        public void PropertiesTest()
        {
            var a = GetClass.Properties(typeof(TestClass));
            Assert.IsNotNull(a);
            Assert.IsInstanceOfType(a, typeof(List<PropertyInfo>));
            Assert.AreEqual(1, a.Count);
            Assert.AreEqual("F", a[0].Name);
        }

        [TestMethod]
        public void ReadWritePropertyValuesTest()
        {
            var o = GetRandom.Object<TestClass>();
            var l = GetClass.ReadWritePropertyValues(o);
            Assert.AreEqual(1, l.Count);
            Assert.AreEqual(l[0], o.F);
        }

        [TestMethod]
        public void PropertyTest()
        {
            static void Test(string name)
                => Assert.AreEqual(name, GetClass.Property<TreatmentView>(name).Name);

            Assert.IsNull(GetClass.Property<TreatmentView>((string)null));
            Assert.IsNull(GetClass.Property<TreatmentView>(string.Empty));
            Assert.IsNull(GetClass.Property<TreatmentView>("bla bla"));
            Test(GetMember.Name<TreatmentView>(m => m.Definition));
            Test(GetMember.Name<TreatmentView>(m => m.Name));
            Test(GetMember.Name<TreatmentView>(m => m.ValidFrom));
            Test(GetMember.Name<TreatmentView>(m => m.ValidTo));
        }

        internal class TestBaseClass
        {

            public void Aaa() => bbb();

            private void bbb() { }

            public static void Ccc() => ddd();

            private static void ddd() { }

        }

        internal class TestClass : TestBaseClass
        {

            public int E = 0;
            public string F { get; set; }

        }

    }
}
