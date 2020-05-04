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
    public class HairdressersRepositoryTests : RepositoryTests<HairdressersRepository, Hairdresser, HairdresserData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SalonDbContext(options);
            dbSet = ((SalonDbContext)db).Hairdressers;
            obj = new HairdressersRepository((SalonDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(IdRepository<Hairdresser, HairdresserData>);

        protected override string GetId(HairdresserData d) => d.Id;

        protected override Hairdresser GetObject(HairdresserData d) => new Hairdresser(d);

        protected override void SetId(HairdresserData d, string id) => d.Id = id;
    }
}