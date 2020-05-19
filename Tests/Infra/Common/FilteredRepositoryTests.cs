using System.Threading.Tasks;
using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Common {

    [TestClass]
    public class FilteredRepositoryTests : AbstractClassTests<FilteredRepository<TreatmentType, TreatmentTypeData>,
        SortedRepository<TreatmentType, TreatmentTypeData>> {

        private class TestClass : FilteredRepository<TreatmentType, TreatmentTypeData> {

            public TestClass(DbContext c, DbSet<TreatmentTypeData> s) : base(c, s) { }

            protected internal override TreatmentType ToDomainObject(TreatmentTypeData d) => new TreatmentType(d);

            protected override async Task<TreatmentTypeData> GetData(string id) {
                return await DbSet.FirstOrDefaultAsync(m => m.Id == id);
            }

            protected override string GetId(TreatmentType entity) => entity?.Data?.Id;

        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();

            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var c = new SalonDbContext(options);
            Obj = new TestClass(c, c.TreatmentTypes);
        }

        [TestMethod] public void SearchStringTest()
            => IsNullableProperty(() => Obj.SearchString, x => Obj.SearchString = x);

        [TestMethod] public void FixedFilterTest()
            => IsNullableProperty(() => Obj.FixedFilter, x => Obj.FixedFilter = x);

        [TestMethod] public void FixedValueTest()
            => IsNullableProperty(() => Obj.FixedValue, x => Obj.FixedValue = x);

        [TestMethod] public void CreateSqlQueryTest() {
            var sql = Obj.CreateSqlQuery();
            Assert.IsNotNull(sql);
        }

        [TestMethod] public void AddFixedFilteringTest() {
            var sql = Obj.CreateSqlQuery();
            var fixedFilter = GetMember.Name<TreatmentTypeData>(x=>x.Name);
            Obj.FixedFilter = fixedFilter;
            var fixedValue = GetRandom.String();
            Obj.FixedValue = fixedValue;
            var sqlNew = Obj.AddFixedFiltering(sql);
            Assert.IsNotNull(sqlNew);
        }

        [TestMethod] public void CreateFixedWhereExpressionTest() {
            var properties = typeof(TreatmentTypeData).GetProperties();
            var idx = GetRandom.Int32(0, properties.Length);
            var p = properties[idx]; 
            Obj.FixedFilter = p.Name;
            var fixedValue = GetRandom.String();
            Obj.FixedValue = fixedValue;
            var e = Obj.CreateFixedWhereExpression();
            Assert.IsNotNull(e);
            var s = e.ToString();
            
            var expected = p.Name;
                if (p.PropertyType != typeof(string))
                    expected += ".ToString()";
                expected += $" == \"{fixedValue}\"";
                Assert.IsTrue(s.Contains(expected));
        }

        [TestMethod] public void CreateFixedWhereExpressionOnFixedFilterNullTest() {
            Assert.IsNull(Obj.CreateFixedWhereExpression());
            Obj.FixedValue = GetRandom.String();
            Obj.FixedFilter = GetRandom.String();
            Assert.IsNull(Obj.CreateFixedWhereExpression());
        }

        [TestMethod] public void AddFilteringTest() {
            var sql = Obj.CreateSqlQuery();
            var searchString = GetRandom.String();
            Obj.SearchString = searchString;
            var sqlNew = Obj.AddFiltering(sql);
            Assert.IsNotNull(sqlNew);
        }

        [TestMethod] public void CreateWhereExpressionTest() {
            var searchString = GetRandom.String();
            Obj.SearchString = searchString;
            var e = Obj.CreateWhereExpression();
            Assert.IsNotNull(e);
            var s = e.ToString();

            foreach (var p in typeof(TreatmentTypeData).GetProperties()) {
                var expected = p.Name;
                if (p.PropertyType != typeof(string))
                   expected += ".ToString()";
                expected += $".Contains(\"{searchString}\")";
                Assert.IsTrue(s.Contains(expected));
            }
        }
        [TestMethod]
        public void CreateWhereExpressionWithNullSearchStringTest()
        {
            Obj.SearchString = null;
            var e = Obj.CreateWhereExpression();
            Assert.IsNull(e);
        }

    }

}