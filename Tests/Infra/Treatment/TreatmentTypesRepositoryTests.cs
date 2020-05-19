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
    public class TreatmentTypesRepositoryTests : RepositoryTests<TreatmentTypesRepository, TreatmentType, TreatmentTypeData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            Db = new SalonDbContext(options);
            DbSet = ((SalonDbContext)Db).TreatmentTypes;
            Obj = new TreatmentTypesRepository((SalonDbContext)Db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(IdRepository<TreatmentType, TreatmentTypeData>);

        protected override string GetId(TreatmentTypeData d) => d.Id;

        protected override TreatmentType GetObject(TreatmentTypeData d) => new TreatmentType(d);

        protected override void SetId(TreatmentTypeData d, string id) => d.Id = id;
    }
}
