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
    public class NailTreatmentsRepositoryTests : RepositoryTests<NailTreatmentsRepository, NailTreatment, NailTreatmentData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                //.UseInMemoryDatabase("TestDb")
                .Options;
            db = new SalonDbContext(options);
            dbSet = ((SalonDbContext)db).NailTreatments;
            obj = new NailTreatmentsRepository((SalonDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(IdRepository<NailTreatment, NailTreatmentData>);

        protected override string GetId(NailTreatmentData d) => d.Id;

        protected override NailTreatment GetObject(NailTreatmentData d) => new NailTreatment(d);

        protected override void SetId(NailTreatmentData d, string id) => d.Id = id;
    }
}
