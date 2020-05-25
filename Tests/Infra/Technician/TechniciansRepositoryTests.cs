using System;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Infra;
using Delux.Infra.Common;
using Delux.Infra.Technician;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Technician
{
    [TestClass]
    public class TechnicianRepositoryTests : RepositoryTests<TechniciansRepository, global::Delux.Domain.Technician.Technician, TechnicianData>
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            Db = new SalonDbContext(options);
            DbSet = ((SalonDbContext)Db).Technicians;
            Obj = new TechniciansRepository((SalonDbContext)Db);
            base.TestInitialize();

        }

        protected override string GetId(TechnicianData d) => d.Id;

        protected override global::Delux.Domain.Technician.Technician GetObject(TechnicianData d) => new global::Delux.Domain.Technician.Technician(d);

        protected override void SetId(TechnicianData d, string id) => d.Id = id;

        protected override Type GetBaseType()
        {
            return typeof(IdRepository<global::Delux.Domain.Technician.Technician, TechnicianData>);
        }
    }
}