using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Infra;
using Delux.Infra.Common;
using Delux.Infra.Treatment;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Treatment
{
    [TestClass]
    public class TreatmentsRepositoryTests : RepositoryTests<TreatmentsRepository, global::Delux.Domain.Treatment.Treatment, TreatmentData>
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            Db = new SalonDbContext(options);
            DbSet = ((SalonDbContext)Db).Treatments;
            Obj = new TreatmentsRepository((SalonDbContext)Db);
            base.TestInitialize();

        }

        protected override string GetId(TreatmentData d) => $"{d.Id}.{d.TreatmentTypeId}";

        protected override global::Delux.Domain.Treatment.Treatment GetObject(TreatmentData d) => new global::Delux.Domain.Treatment.Treatment(d);

        protected override void SetId(TreatmentData d, string id)
        {
            var masterId = GetString.Head(id);
            var treatmentTypeId = GetString.Tail(id);
            d.Id = masterId;
            d.TreatmentTypeId = treatmentTypeId;
        }

        protected override Type GetBaseType()
        {
            return typeof(IdRepository<global::Delux.Domain.Treatment.Treatment, TreatmentData>);
        }
    }
}
