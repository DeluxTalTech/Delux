using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Common;
using Delux.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra
{
    [TestClass]
    public class SalonDbInitializerTests : BaseTests
    {

        private SalonDbContext _db;

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(SalonDbInitializer);
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            _db = new SalonDbContext(options);
            SalonDbInitializer.Initialize(_db);
        }

        [TestMethod]
        public void InitializeTest()
        {

        }

        private int GetCount<T>(DbSet<T> dbSet)
            where T : IdData, new()
        {
            return dbSet.CountAsync().GetAwaiter().GetResult();
        }

        [TestMethod]
        public void TreatmentTypesTest() => Assert.AreEqual(4, GetCount(_db.TreatmentTypes));

        [TestMethod]
        public void TechnicianTypesTest() => Assert.AreEqual(4, GetCount(_db.TechnicianTypes));

        [TestMethod]
        public void TreatmentsTest() => Assert.AreEqual(16, GetCount(_db.Treatments));

        [TestMethod]
        public void TechniciansTest() => Assert.AreEqual(0, GetCount(_db.Technicians));

        [TestMethod]
        public void ClientsTest() => Assert.AreEqual(6, GetCount(_db.Clients));

        //[TestMethod]
        //public void AppointmentsTest() => Assert.AreEqual(2, GetCount(db.Appointments));
    }
}
