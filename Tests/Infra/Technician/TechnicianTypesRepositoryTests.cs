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
    public class TechnicianTypesRepositoryTests : RepositoryTests<TechnicianTypesRepository, TechnicianType, TechnicianTypeData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            Db = new SalonDbContext(options);
            DbSet = ((SalonDbContext)Db).TechnicianTypes;
            Obj = new TechnicianTypesRepository((SalonDbContext)Db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(IdRepository<TechnicianType, TechnicianTypeData>);

        protected override string GetId(TechnicianTypeData d) => d.Id;

        protected override TechnicianType GetObject(TechnicianTypeData d) => new TechnicianType(d);

        protected override void SetId(TechnicianTypeData d, string id) => d.Id = id;
    }
}