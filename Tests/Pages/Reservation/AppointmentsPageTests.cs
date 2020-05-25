using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Delux.Data.Client;
using Delux.Data.Reservation;
using Delux.Data.Technician;
using Delux.Domain.Client;
using Delux.Domain.Reservation;
using Delux.Domain.Technician;
using Delux.Facade.Client;
using Delux.Facade.Reservation;
using Delux.Facade.Technician;
using Delux.Infra.Technician;
using Delux.Pages.Client;
using Delux.Pages.Common;
using Delux.Pages.Reservation;
using Delux.Pages.Technician;
using Delux.Tests.Pages.Client;
using Delux.Tests.Pages.Technician;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Reservation
{
    [TestClass]
    public class AppointmentsPageTests:AbstractClassTests<AppointmentsPage,
    CommonPage<IAppointmentsRepository,Appointment, AppointmentView,AppointmentData>>
    {
        //private class TestClass : AppointmentsPage
        //{
        //    internal TestClass(IAppointmentsRepository t) : base(t) { }
        //}

        private class AppointmentRepository : BaseTestRepositoryForId<Appointment, AppointmentData>, IAppointmentsRepository
        {
        }


        private AppointmentRepository _appointments;
       

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _appointments = new AppointmentRepository();
            
            //Obj = new AppointmentsPageTests().TestClass(_appointments);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Broneeringud", Obj.PageTitle);


        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Salon/Appointments", Obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<AppointmentView>();
            var o = Obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<AppointmentData>();
            var view = Obj.ToView(new Appointment(d));
            TestArePropertyValuesEqual(view, d);
        }
    }
}
