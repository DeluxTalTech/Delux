using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Delux.Aids;
using Delux.Data.Reservation;
using Delux.Data.Treatment;
using Delux.Domain.Reservation;
using Delux.Domain.Treatment;
using Delux.Infra;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Common
{

    [TestClass]
    public class SortedRepositoryTests : AbstractClassTests<SortedRepository<Appointment, AppointmentData>,
        BaseRepository<Appointment, AppointmentData>>
    {

        private class TestClass : SortedRepository<Appointment, AppointmentData>
        {

            public TestClass(DbContext c, DbSet<AppointmentData> a) : base(c, a) { }

            protected internal override Appointment ToDomainObject(AppointmentData d) => new Appointment(d);

            protected override async Task<AppointmentData> GetData(string id)
            {
                await Task.CompletedTask;
                return new AppointmentData();
            }

            protected override string GetId(Appointment entity) => entity?.Data?.Id;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<SalonDbContext>().UseInMemoryDatabase("TestDb").Options;
            var c = new SalonDbContext(options);
            Obj = new TestClass(c, c.Appointments);
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
            void Test(IQueryable<AppointmentData> d, string sortOrder)
            {
                Obj.SortOrder = sortOrder + Obj.DescendingString;
                var set = Obj.AddSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                var str = set.Expression.ToString();
                Assert.IsTrue(str
                    .Contains($"Delux.Data.AppointmentData]).OrderByDescending(x => Convert(x.{sortOrder}, Object))"));
                Obj.SortOrder = sortOrder;
                set = Obj.AddSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                str = set.Expression.ToString();
                Assert.IsTrue(str.Contains($"Delux.Data.AppointmentData]).OrderBy(x => Convert(x.{sortOrder}, Object))"));
            }

            Assert.IsNull(Obj.AddSorting(null));
            IQueryable<AppointmentData> data = Obj.DbSet;
            Obj.SortOrder = null;
            Assert.AreEqual(data, Obj.AddSorting(data));
            Test(data, GetMember.Name<AppointmentData>(x => x.Id));
        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            string s;
            TestCreateExpression(GetMember.Name<AppointmentData>(x => x.Id));
            TestCreateExpression(GetMember.Name<AppointmentData>(x => x.ClientId));
            TestCreateExpression(GetMember.Name<AppointmentData>(x => x.TreatmentId));
            TestCreateExpression(GetMember.Name<AppointmentData>(x => x.TechnicianId));
            TestCreateExpression(GetMember.Name<AppointmentData>(x => x.AppointmentDateTime));

            TestCreateExpression(s = GetMember.Name<AppointmentData>(x => x.Id), s + Obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<AppointmentData>(x => x.ClientId), s + Obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<AppointmentData>(x => x.TreatmentId), s + Obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<AppointmentData>(x => x.TechnicianId), s + Obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<AppointmentData>(x => x.AppointmentDateTime), s + Obj.DescendingString);

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
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<AppointmentData, Object>>));
            Assert.IsTrue(lambda.ToString().Contains(expected));
        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            var id = GetMember.Name<AppointmentData>(x => x.Id);
            var property = typeof(AppointmentData).GetProperty(id);
            var lambda = Obj.LambdaExpression(property);
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<AppointmentData, Object>>));
            Assert.IsTrue(lambda.ToString().Contains(id));
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
            Test(typeof(AppointmentData).GetProperty(s = GetMember.Name<AppointmentData>(x => x.Id)), s);
            Test(typeof(AppointmentData).GetProperty(s = GetMember.Name<AppointmentData>(x => x.ClientId)), s);
            Test(typeof(AppointmentData).GetProperty(s = GetMember.Name<AppointmentData>(x => x.TreatmentId)), s);
            Test(typeof(AppointmentData).GetProperty(s = GetMember.Name<AppointmentData>(x => x.TechnicianId)), s);
            Test(typeof(AppointmentData).GetProperty(s = GetMember.Name<AppointmentData>(x => x.AppointmentDateTime)), s);

            Test(typeof(AppointmentData).GetProperty(s = GetMember.Name<AppointmentData>(x => x.Id)), s + Obj.DescendingString);
            Test(typeof(AppointmentData).GetProperty(s = GetMember.Name<AppointmentData>(x => x.ClientId)), s + Obj.DescendingString);
            Test(typeof(AppointmentData).GetProperty(s = GetMember.Name<AppointmentData>(x => x.TreatmentId)), s + Obj.DescendingString);
            Test(typeof(AppointmentData).GetProperty(s = GetMember.Name<AppointmentData>(x => x.TechnicianId)), s + Obj.DescendingString);
            Test(typeof(AppointmentData).GetProperty(s = GetMember.Name<AppointmentData>(x => x.AppointmentDateTime)), s + Obj.DescendingString);

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
            void Test(IQueryable<AppointmentData> d, Expression<Func<AppointmentData, Object>> e, string expected)
            {
                Obj.SortOrder = GetRandom.String() + Obj.DescendingString;
                var set = Obj.AddOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                Assert.IsTrue(set.Expression.ToString()
                    .Contains($"Delux.Data.AppointmentData]).OrderByDescending({expected})"));
                Obj.SortOrder = GetRandom.String();
                set = Obj.AddOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                Assert.IsTrue(set.Expression.ToString().Contains($"Delux.Data.AppointmentData]).OrderBy({expected})"));
            }

            Assert.IsNull(Obj.AddOrderBy(null, null));
            IQueryable<AppointmentData> data = Obj.DbSet;
            Assert.AreEqual(data, Obj.AddOrderBy(data, null));
            Test(data, x => x.Id, "x => x.Id");
            Test(data, x => x.ClientId, "x => x.ClientId");
            Test(data, x => x.TreatmentId, "x => x.TreatmentId");
            Test(data, x => x.TechnicianId, "x => x.TechnicianId");
            Test(data, x => x.AppointmentDateTime, "x => x.AppointmentDateTime");
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
