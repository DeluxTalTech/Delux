using System;
using System.Threading.Tasks;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Infra;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Common
{
    [TestClass]
    public class PaginatedRepositoryTests :
        AbstractClassTests<PaginatedRepository<Beautician, BeauticianData>, FilteredRepository<Beautician, BeauticianData>>
    {

        private class TestClass : PaginatedRepository<Beautician, BeauticianData>
        {

            public TestClass(DbContext c, DbSet<BeauticianData> s) : base(c, s) { }

            protected internal override Beautician ToDomainObject(BeauticianData d) => new Beautician(d);

            protected override async Task<BeauticianData> GetData(string id)
             => await DbSet.FirstOrDefaultAsync(m => m.Id == id);
            
            protected override string GetId(Beautician entity) => entity?.Data?.Id;

        }

        private byte count;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var c = new SalonDbContext(options);
            Obj = new TestClass(c, c.Beauticians);
            count = GetRandom.UInt8(20, 40);
            foreach (var p in c.Beauticians)
            {
                c.Entry(p).State = EntityState.Deleted;
            }
            AddItems();
        }
        
        [TestMethod]
        public void PageIndexTest()
        {
            IsProperty(() => Obj.PageIndex, x => Obj.PageIndex = x);
        }

        [TestMethod]
        public void TotalPagesTest()
        {
            var expected = (int) Math.Ceiling(count / (double) Obj.PageSize);
            var totalPagesCount = Obj.TotalPages;
            Assert.AreEqual(expected, totalPagesCount);
        }

        [TestMethod]
        public void HasNextPageTest()
        {
            void TestNextPage(int pageIndex, bool expected)
            {
                Obj.PageIndex = pageIndex;
                var actual = Obj.HasNextPage;
                Assert.AreEqual(expected, actual);
            }
            TestNextPage(0, true);
            TestNextPage(1, true);
            TestNextPage(GetRandom.Int32(2, Obj.TotalPages - 1), true);
            TestNextPage(Obj.TotalPages, false);
        }

        [TestMethod]
        public void HasPreviousPageTest()
        {
            void TestPreviousPage(int pageIndex, bool expected)
            {
                Obj.PageIndex = pageIndex;
                var actual = Obj.HasPreviousPage;
                Assert.AreEqual(expected, actual);
            }
            TestPreviousPage(0, false);
            TestPreviousPage(1, false);
            TestPreviousPage(2, true);
            TestPreviousPage(GetRandom.Int32(2, Obj.TotalPages), true);
            TestPreviousPage(Obj.TotalPages, true);
        }

        [TestMethod]
        public void PageSizeTest()
        {
            Assert.AreEqual(5, Obj.PageSize);
            IsProperty(() => Obj.PageSize, x => Obj.PageSize = x);
        }

        [TestMethod]
        public void GetTotalPagesTest()
        {
            var expected = (int)Math.Ceiling(count / (double)Obj.PageSize);
            var totalPagesCount = Obj.GetTotalPages(Obj.PageSize);
            Assert.AreEqual(expected, totalPagesCount);
        }

        [TestMethod]
        public void CountTotalPagesTest()
        {
            var expected = (int) Math.Ceiling(count / (double) Obj.PageSize);
            var totalPagesCount = Obj.CountTotalPages(count, Obj.PageSize);
            Assert.AreEqual(expected, totalPagesCount);
        }

        [TestMethod]
        public void GetItemsCountTest()
        {
            var itemsCount = Obj.GetItemsCount();
            Assert.AreEqual(0, itemsCount);
        }

        private void AddItems()
        {
            for (var i = 0; i < count; i++)
                Obj.Add(new Beautician(GetRandom.Object<BeauticianData>())).GetAwaiter();
        }

        [TestMethod]
        public void CreateSqlQueryTest()
        {
            var o = Obj.CreateSqlQuery();
            Assert.IsNotNull(o);
        }

        [TestMethod]
        public void AddSkipAndTakeTest()
        {
            var sql = Obj.CreateSqlQuery();
            var o = Obj.AddSkipAndTake(sql);
            Assert.IsNotNull(o);
        }
    }
}
