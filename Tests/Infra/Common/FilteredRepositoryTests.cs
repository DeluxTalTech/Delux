using System.Threading.Tasks;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Infra;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Common {

    [TestClass]
    public class FilteredRepositoryTests : AbstractClassTests<FilteredRepository<Beautician, BeauticianData>,
        SortedRepository<Beautician, BeauticianData>> {

        private class TestClass : FilteredRepository<Beautician, BeauticianData> {

            public TestClass(DbContext c, DbSet<BeauticianData> s) : base(c, s) { }

            protected internal override Beautician ToDomainObject(BeauticianData d) => new Beautician(d);

            protected override async Task<BeauticianData> GetData(string id) {
                return await DbSet.FirstOrDefaultAsync(m => m.Id == id);
            }

            protected override string GetId(Beautician entity) => entity?.Data?.Id;

        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();

            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var c = new SalonDbContext(options);
            Obj = new TestClass(c, c.Beauticians);
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
            var fixedFilter = GetMember.Name<BeauticianData>(x=>x.Definition);
            Obj.FixedFilter = fixedFilter;
            var fixedValue = GetRandom.String();
            Obj.FixedValue = fixedValue;
            var sqlNew = Obj.AddFixedFiltering(sql);
            Assert.IsNotNull(sqlNew);
        }

        [TestMethod] public void CreateFixedWhereExpressionTest() {
            var properties = typeof(BeauticianData).GetProperties();
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

            foreach (var p in typeof(BeauticianData).GetProperties()) {
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