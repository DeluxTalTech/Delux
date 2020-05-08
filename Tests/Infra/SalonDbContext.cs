using System;
using System.Linq;
using System.Linq.Expressions;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Delux.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra
{
    [TestClass]
    public class SalonDbContextTests : BaseClassTests<SalonDbContext, DbContext>
    {
        private DbContextOptions<SalonDbContext> options;

        private class TestClass : SalonDbContext
        {

            public TestClass(DbContextOptions<SalonDbContext> o) : base(o) { }

            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);
                return mb;
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            options = new DbContextOptionsBuilder<SalonDbContext>().UseInMemoryDatabase("TestDb").Options;
            Obj = new SalonDbContext(options);
        }

        [TestMethod]
        public void InitializeTablesTest()
        {
            static void testKey<T>(IMutableEntityType entity, params Expression<Func<T, object>>[] values)
            {
                var key = entity.FindPrimaryKey();
                if (values is null) Assert.IsNull(key);
                else
                {
                    foreach (var v in values)
                    {
                        var name = GetMember.Name(v);
                        Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == name));
                    }
                }
            }

            static void testEntity<T>(ModelBuilder b, params Expression<Func<T, object>>[] values)
            {
                var name = typeof(T).FullName ?? string.Empty;
                var entity = b.Model.FindEntityType(name);
                Assert.IsNotNull(entity, name);
                testKey(entity, values);
            }

            SalonDbContext.InitializeTables(null);
            var o = new TestClass(options);
            var builder = o.RunOnModelCreating();
            SalonDbContext.InitializeTables(builder);
            testEntity<BeauticianData>(builder);
            testEntity<HairdresserData>(builder);
            testEntity<MasseuseData>(builder);
            testEntity<NailTechnicianData>(builder);
            testEntity<FacialTreatmentData>(builder);
            testEntity<HairTreatmentData>(builder);
            testEntity<MassageTreatmentData>(builder);
            testEntity<NailTreatmentData>(builder);

        }

        [TestMethod]
        public void BeauticiansTest() =>
            IsNullableProperty(Obj, nameof(Obj.Beauticians), typeof(DbSet<BeauticianData>));

        [TestMethod] public void HairdressersTest() => IsNullableProperty(Obj, nameof(Obj.Hairdressers), typeof(DbSet<HairdresserData>));

        [TestMethod]
        public void MasseusesTest() =>
            IsNullableProperty(Obj, nameof(Obj.Masseuses), typeof(DbSet<MasseuseData>));

        [TestMethod]
        public void NailTechniciansTest() =>
            IsNullableProperty(Obj, nameof(Obj.NailTechnicians), typeof(DbSet<NailTechnicianData>));

        [TestMethod]
        public void FacialTreatmentsTest() =>
            IsNullableProperty(Obj, nameof(Obj.FacialTreatments), typeof(DbSet<FacialTreatmentData>));

        [TestMethod]
        public void HairTreatmentsTest() =>
            IsNullableProperty(Obj, nameof(Obj.HairTreatments), typeof(DbSet<HairTreatmentData>));

        [TestMethod]
        public void MassageTreatmentsTest() =>
            IsNullableProperty(Obj, nameof(Obj.MassageTreatments), typeof(DbSet<MassageTreatmentData>));

        [TestMethod]
        public void NailTreatmentsTest() =>
            IsNullableProperty(Obj, nameof(Obj.NailTreatments), typeof(DbSet<NailTreatmentData>));
    }
}
