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
    public class MassageTreatmentsRepositoryTests : RepositoryTests<MassageTreatmentsRepository, MassageTreatment, MassageTreatmentData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SalonDbContext(options);
            dbSet = ((SalonDbContext)db).MassageTreatments;
            obj = new MassageTreatmentsRepository((SalonDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(IdRepository<MassageTreatment, MassageTreatmentData>);

        protected override string GetId(MassageTreatmentData d) => d.Id;

        protected override MassageTreatment GetObject(MassageTreatmentData d) => new MassageTreatment(d);

        protected override void SetId(MassageTreatmentData d, string id) => d.Id = id;
    }
}
