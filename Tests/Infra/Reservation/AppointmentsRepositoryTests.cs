using System;
using Delux.Data.Reservation;
using Delux.Domain.Reservation;
using Delux.Infra;
using Delux.Infra.Common;
using Delux.Infra.Reservation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra.Reservation
{
    [TestClass]
    public class AppointmentsRepositoryTests : RepositoryTests<AppointmentsRepository, Appointment, AppointmentData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            Db = new SalonDbContext(options);
            DbSet = ((SalonDbContext)Db).Appointments;
            Obj = new AppointmentsRepository((SalonDbContext)Db);
            base.TestInitialize();

        }

        protected override string GetId(AppointmentData d) => d.Id;

        protected override Appointment GetObject(AppointmentData d) => new Appointment(d);

        protected override void SetId(AppointmentData d, string id) => d.Id = id;

        protected override Type GetBaseType()
        {
            return typeof(IdRepository<Appointment, AppointmentData>);
        }
    }
}
