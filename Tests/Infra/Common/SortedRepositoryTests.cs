using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Infra;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Common
{

    [TestClass]
    public class SortedRepositoryTests : AbstractClassTests<SortedRepository<TreatmentType, TreatmentTypeData>,
        BaseRepository<TreatmentType, TreatmentTypeData>>
    {

        private class TestClass : SortedRepository<TreatmentType, TreatmentTypeData>
        {

            public TestClass(DbContext c, DbSet<TreatmentTypeData> s) : base(c, s) { }

            protected internal override TreatmentType ToDomainObject(TreatmentTypeData d) => new TreatmentType(d);

            protected override async Task<TreatmentTypeData> GetData(string id)
            {
                await Task.CompletedTask;
                return new TreatmentTypeData();
            }

            protected override string GetId(TreatmentType entity) => entity?.Data?.Id;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<SalonDbContext>().UseInMemoryDatabase("TestDb").Options;
            var c = new SalonDbContext(options);
            Obj = new TestClass(c, c.TreatmentTypes);
        }

        [TestMethod]
        public void SortOrderTest()
        {
            IsNullableProperty(() => Obj.SortOrder, x => Obj.SortOrder = x);
        }

        [TestMethod]
        public void DescendingStringTest()
        {

            var propertyName = GetMember.Name<TestClass>(x => x.DescendingString);
            IsReadOnlyProperty(Obj, propertyName, "_desc");
        }

        [TestMethod]
        public void SetSortingTest()
        {
            void Test(IQueryable<TreatmentTypeData> d, string sortOrder)
            {
                Obj.SortOrder = sortOrder + Obj.DescendingString;
                var set = Obj.AddSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                var str = set.Expression.ToString();
                Assert.IsTrue(str
                    .Contains($"Delux.Data.TreatmentTypeData]).OrderByDescending(x => Convert(x.{sortOrder}, Object))"));
                Obj.SortOrder = sortOrder;
                set = Obj.AddSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                str = set.Expression.ToString();
                Assert.IsTrue(str.Contains($"Delux.Data.TreatmentTypeData]).OrderBy(x => Convert(x.{sortOrder}, Object))"));
            }

            Assert.IsNull(Obj.AddSorting(null));
            IQueryable<TreatmentTypeData> data = Obj.DbSet;
            Obj.SortOrder = null;
            Assert.AreEqual(data, Obj.AddSorting(data));
            Test(data, GetMember.Name<TreatmentTypeData>(x => x.Id));
            Test(data, GetMember.Name<TreatmentTypeData>(x => x.Name));
        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            string s;
            TestCreateExpression(GetMember.Name<TreatmentTypeData>(x => x.Id));
            TestCreateExpression(GetMember.Name<TreatmentTypeData>(x => x.Name));
            TestCreateExpression(s = GetMember.Name<TreatmentTypeData>(x => x.Id), s + Obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<TreatmentTypeData>(x => x.Name), s + Obj.DescendingString);
            TestNullExpression(GetRandom.String());
            TestNullExpression(string.Empty);
            TestNullExpression(null);
        }

        private void TestNullExpression(string name)
        {
            Obj.SortOrder = name;
            var lambda = Obj.CreateExpression();
            Assert.IsNull(lambda);
        }

        private void TestCreateExpression(string expected, string name = null)
        {
            name ??= expected;
            Obj.SortOrder = name;
            var lambda = Obj.CreateExpression();
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<TreatmentTypeData, Object>>));
            Assert.IsTrue(lambda.ToString().Contains(expected));
        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            var name = GetMember.Name<TreatmentTypeData>(x => x.Name);
            var property = typeof(TreatmentTypeData).GetProperty(name);
            var lambda = Obj.LambdaExpression(property);
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<TreatmentTypeData, Object>>));
            Assert.IsTrue(lambda.ToString().Contains(name));
        }

        [TestMethod]
        public void FindPropertyTest()
        {
            string s;

            void Test(PropertyInfo expected, string sortOrder)
            {
                Obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, Obj.FindProperty());
            }

            Test(null, GetRandom.String());
            Test(null, null);
            Test(null, string.Empty);
            Test(typeof(TreatmentTypeData).GetProperty(s = GetMember.Name<TreatmentTypeData>(x => x.Name)), s);
            Test(typeof(TreatmentTypeData).GetProperty(s = GetMember.Name<TreatmentTypeData>(x => x.Id)), s);
            Test(typeof(TreatmentTypeData).GetProperty(s = GetMember.Name<TreatmentTypeData>(x => x.Name)), s + Obj.DescendingString);
            Test(typeof(TreatmentTypeData).GetProperty(s = GetMember.Name<TreatmentTypeData>(x => x.Id)), s + Obj.DescendingString);
        }

        [TestMethod]
        public void GetNameTest()
        {
            string s;

            void Test(string expected, string sortOrder)
            {
                Obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, Obj.GetName());
            }

            Test(s = GetRandom.String(), s);
            Test(s = GetRandom.String(), s + Obj.DescendingString);
            Test(string.Empty, string.Empty);
            Test(string.Empty, null);
        }

        [TestMethod]
        public void SetOrderByTest()
        {
            void Test(IQueryable<TreatmentTypeData> d, Expression<Func<TreatmentTypeData, Object>> e, string expected)
            {
                Obj.SortOrder = GetRandom.String() + Obj.DescendingString;
                var set = Obj.AddOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                Assert.IsTrue(set.Expression.ToString()
                    .Contains($"Delux.Data.TreatmentTypeData]).OrderByDescending({expected})"));
                Obj.SortOrder = GetRandom.String();
                set = Obj.AddOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                Assert.IsTrue(set.Expression.ToString().Contains($"Delux.Data.TreatmentTypeData]).OrderBy({expected})"));
            }

            Assert.IsNull(Obj.AddOrderBy(null, null));
            IQueryable<TreatmentTypeData> data = Obj.DbSet;
            Assert.AreEqual(data, Obj.AddOrderBy(data, null));
            Test(data, x => x.Id, "x => x.Id");
            Test(data, x => x.Name, "x => x.Name");
        }

        [TestMethod]
        public void IsDescendingTest()
        {
            void Test(string sortOrder, bool expected)
            {
                Obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, Obj.IsDescending());
            }

            Test(GetRandom.String(), false);
            Test(GetRandom.String() + Obj.DescendingString, true);
            Test(string.Empty, false);
            Test(null, false);
        }

    }

}
