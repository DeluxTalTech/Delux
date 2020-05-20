using System;
using System.Linq;
using System.Linq.Expressions;
using Delux.Aids;
using Delux.Data.Client;
using Delux.Data.Reservation;
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
        private DbContextOptions<SalonDbContext> _options;

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
            _options = new DbContextOptionsBuilder<SalonDbContext>().UseInMemoryDatabase("TestDb").Options;
            Obj = new SalonDbContext(_options);
        }

        [TestMethod]
        public void InitializeTablesTest()
        {
            static void TestKey<T>(IMutableEntityType entity, params Expression<Func<T, object>>[] values)
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

            static void TestEntity<T>(ModelBuilder b, params Expression<Func<T, object>>[] values)
            {
                var name = typeof(T).FullName ?? string.Empty;
                var entity = b.Model.FindEntityType(name);
                Assert.IsNotNull(entity, name);
                TestKey(entity, values);
            }

            SalonDbContext.InitializeTables(null);
            var o = new TestClass(_options);
            var builder = o.RunOnModelCreating();
            SalonDbContext.InitializeTables(builder);
            TestEntity<TreatmentTypeData>(builder);
            TestEntity<TechnicianTypeData>(builder);
            TestEntity<TreatmentData>(builder, x => x.Id, x => x.TreatmentTypeId);
            TestEntity<TechnicianData>(builder, x => x.Id, x => x.TechnicianTypeId);
            TestEntity<ClientData>(builder);
            //TestEntity<AppointmentData>(builder, x => x.ClientId, x => x.TreatmentId, x => x.TechnicianId);

        }

        [TestMethod]
        public void TreatmentTypesTest() => IsNullableProperty(Obj, nameof(Obj.TreatmentTypes), typeof(DbSet<TreatmentTypeData>));

        [TestMethod]
        public void TechnicianTypesTest() => IsNullableProperty(Obj, nameof(Obj.TechnicianTypes), typeof(DbSet<TechnicianTypeData>));

        [TestMethod]
        public void TreatmentsTest() => IsNullableProperty(Obj, nameof(Obj.Treatments), typeof(DbSet<TreatmentData>));

        [TestMethod]
        public void TechniciansTest() => IsNullableProperty(Obj, nameof(Obj.Technicians), typeof(DbSet<TechnicianData>));

        [TestMethod]
        public void ClientsTest() => IsNullableProperty(Obj, nameof(Obj.Clients), typeof(DbSet<ClientData>));

        [TestMethod]
        public void AppointmentsTest() => IsNullableProperty(Obj, nameof(Obj.Appointments), typeof(DbSet<AppointmentData>));
    }
}
