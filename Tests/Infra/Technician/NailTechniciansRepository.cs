using System;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Infra;
using Delux.Infra.Common;
using Delux.Infra.Technician;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Technician
{
    [TestClass]
    public class FacialTreatmentsRepositoryTests : RepositoryTests<NailTechniciansRepository, NailTechnician, NailTechnicianData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            Db = new SalonDbContext(options);
            DbSet = ((SalonDbContext)Db).NailTechnicians;
            Obj = new NailTechniciansRepository((SalonDbContext)Db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(IdRepository<NailTechnician, NailTechnicianData>);

        protected override string GetId(NailTechnicianData d) => d.Id;

        protected override NailTechnician GetObject(NailTechnicianData d) => new NailTechnician(d);

        protected override void SetId(NailTechnicianData d, string id) => d.Id = id;
    }
}