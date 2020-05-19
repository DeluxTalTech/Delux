using System.Threading.Tasks;
using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Common
{
    [TestClass]
    public class BaseRepositoryTests : AbstractClassTests<BaseRepository<TreatmentType, TreatmentTypeData>, object>
    {
        private TreatmentTypeData _data;

        private class TestClass : BaseRepository<TreatmentType, TreatmentTypeData>
        {

            public TestClass(DbContext c, DbSet<TreatmentTypeData> s) : base(c, s) { }

            protected internal override TreatmentType ToDomainObject(TreatmentTypeData d) => new TreatmentType(d);

            protected override async Task<TreatmentTypeData> GetData(string id)
            {
                return await DbSet.FirstOrDefaultAsync(m => m.Id == id);
            }

            protected override string GetId(TreatmentType entity) => entity?.Data?.Id;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var c = new SalonDbContext(options);
            Obj = new TestClass(c, c.TreatmentTypes);
            _data = GetRandom.Object<TreatmentTypeData>();
        }


        [TestMethod]
        public void GetTest()
        {
            var count = GetRandom.UInt8(15, 30);
            var countBefore = Obj.Get().GetAwaiter().GetResult().Count;
            for (var i = 0; i < count; i++)
            {
                _data = GetRandom.Object<TreatmentTypeData>();
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
            var expected = Obj.Get(_data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(_data, expected.Data);
            Obj.Delete(_data.Id).GetAwaiter();
            expected = Obj.Get(_data.Id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
        }

        public void AddTest()
        {
            var expected = Obj.Get(_data.Id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
            Obj.Add(new TreatmentType(_data)).GetAwaiter();
            expected = Obj.Get(_data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(_data, expected.Data);
        }

        public void UpdateTest()
        {
            AddTest();
            var newData = GetRandom.Object<TreatmentTypeData>();
            newData.Id = _data.Id;
            Obj.Update(new TreatmentType(newData)).GetAwaiter();
            var expected = Obj.Get(_data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(newData, expected.Data);
        }
    }
}
