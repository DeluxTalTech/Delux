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
    public class FacialTreatmentsRepositoryTests:RepositoryTests<FacialTreatmentsRepository, FacialTreatment,FacialTreatmentData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                //.UseInMemoryDatabase("TestDb")
                .Options;
            db = new SalonDbContext(options);
            dbSet = ((SalonDbContext)db).FacialTreatments;
            obj = new FacialTreatmentsRepository((SalonDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(IdRepository<FacialTreatment, FacialTreatmentData>);

        protected override string GetId(FacialTreatmentData d) => d.Id;

        protected override FacialTreatment GetObject(FacialTreatmentData d) => new FacialTreatment(d);

        protected override void SetId(FacialTreatmentData d, string id) => d.Id = id;
    }
}
