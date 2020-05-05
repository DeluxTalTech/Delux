using System;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra;
using Delux.Infra.Common;
using Delux.Infra.Treatment;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Treatment
{
    [TestClass]
    public class HairTreatmentsRepositoryTests : RepositoryTests<HairTreatmentsRepository, HairTreatment, HairTreatmentData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            Db = new SalonDbContext(options);
            DbSet = ((SalonDbContext)Db).HairTreatments;
            Obj = new HairTreatmentsRepository((SalonDbContext)Db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(IdRepository<HairTreatment, HairTreatmentData>);

        protected override string GetId(HairTreatmentData d) => d.Id;

        protected override HairTreatment GetObject(HairTreatmentData d) => new HairTreatment(d);

        protected override void SetId(HairTreatmentData d, string id) => d.Id = id;
    }
}
