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
    public class BaseRepositoryTests : AbstractClassTests<BaseRepository<Beautician, BeauticianData>, object>
    {
        private BeauticianData Data;

        private class TestClass : BaseRepository<Beautician, BeauticianData>
        {

            public TestClass(DbContext c, DbSet<BeauticianData> s) : base(c, s) { }

            protected internal override Beautician ToDomainObject(BeauticianData d) => new Beautician(d);

            protected override async Task<BeauticianData> GetData(string id)
            {
                return await DbSet.FirstOrDefaultAsync(m => m.Id == id);
            }

            protected override string GetId(Beautician entity) => entity?.Data?.Id;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var c = new SalonDbContext(options);
            Obj = new TestClass(c, c.Beauticians);
            Data = GetRandom.Object<BeauticianData>();
        }


        [TestMethod]
        public void GetTest()
        {
            var count = GetRandom.UInt8(15, 30);
            var countBefore = Obj.Get().GetAwaiter().GetResult().Count;
            for (var i = 0; i < count; i++)
            {
                Data = GetRandom.Object<BeauticianData>();
                AddTest();
            }
            Assert.AreEqual(count + countBefore, Obj.Get().GetAwaiter().GetResult().Count);
        }

        public void GetByIdTest()
        {
            AddTest();
        }

        public void DeleteTest()
        {
            AddTest();
            var expected = Obj.Get(Data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(Data, expected.Data);
            Obj.Delete(Data.Id).GetAwaiter();
            expected = Obj.Get(Data.Id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
        }

        public void AddTest()
        {
            var expected = Obj.Get(Data.Id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
            Obj.Add(new Beautician(Data)).GetAwaiter();
            expected = Obj.Get(Data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(Data, expected.Data);
        }

        public void UpdateTest()
        {
            AddTest();
            var newData = GetRandom.Object<BeauticianData>();
            newData.Id = Data.Id;
            Obj.Update(new Beautician(newData)).GetAwaiter();
            var expected = Obj.Get(Data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(newData, expected.Data);
        }
    }
}
