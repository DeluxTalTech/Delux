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
    public class MasseusesRepositoryTests : RepositoryTests<MasseusesRepository, Masseuse, MasseuseData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SalonDbContext(options);
            dbSet = ((SalonDbContext)db).Masseuses;
            obj = new MasseusesRepository((SalonDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(IdRepository<Masseuse, MasseuseData>);

        protected override string GetId(MasseuseData d) => d.Id;

        protected override Masseuse GetObject(MasseuseData d) => new Masseuse(d);

        protected override void SetId(MasseuseData d, string id) => d.Id = id;
    }
}