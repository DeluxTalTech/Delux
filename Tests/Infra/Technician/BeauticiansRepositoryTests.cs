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
    public class BeauticiansRepositoryTests : RepositoryTests<BeauticiansRepository, Beautician, BeauticianData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SalonDbContext(options);
            dbSet = ((SalonDbContext)db).Beauticians;
            obj = new BeauticiansRepository((SalonDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(IdRepository<Beautician, BeauticianData>);

        protected override string GetId(BeauticianData d) => d.Id;

        protected override Beautician GetObject(BeauticianData d) => new Beautician(d);

        protected override void SetId(BeauticianData d, string id) => d.Id = id;
    }
}