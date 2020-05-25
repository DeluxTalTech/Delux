using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delux.Aids;
using Delux.Data.Client;
using Delux.Data.Reservation;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Delux.Domain.Client;
using Delux.Domain.Reservation;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
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
        private class TestClass : AppointmentsPage
        {
            internal TestClass(IAppointmentsRepository a, IClientsRepository c, ITreatmentsRepository tr, ITechniciansRepository te) 
                : base(a, c, tr, te) { }
        }

        private class AppointmentsRepository : BaseTestRepositoryForId<Appointment, AppointmentData>, IAppointmentsRepository { }

        private class ClientsRepository : BaseTestRepositoryForId<global::Delux.Domain.Client.Client, ClientData>, IClientsRepository { }

        private class TreatmentsRepository : BaseTestRepositoryForId<global::Delux.Domain.Treatment.Treatment, TreatmentData>, ITreatmentsRepository { }

        private class TechniciansRepository : BaseTestRepositoryForId<global::Delux.Domain.Technician.Technician, TechnicianData>, ITechniciansRepository { }



        private AppointmentsRepository _appointments;
        private ClientsRepository _clients;
        private ClientData _clientData;
        private TreatmentsRepository _treatments;
        private TreatmentData _treatmentData;
        private TechniciansRepository _technicians;
        private TechnicianData _technicianData;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _appointments = new AppointmentsRepository();
            _clients = new ClientsRepository();
            _treatments = new TreatmentsRepository();
            _technicians = new TechniciansRepository();
            _clientData = GetRandom.Object<ClientData>();
            var c = new global::Delux.Domain.Client.Client(_clientData);
            _clients.Add(c).GetAwaiter();
            AddRandomClients();
            _treatmentData = GetRandom.Object<TreatmentData>();
            var tr = new global::Delux.Domain.Treatment.Treatment(_treatmentData);
            _treatments.Add(tr).GetAwaiter();
            AddRandomTreatments();
            _technicianData = GetRandom.Object<TechnicianData>();
            var te = new global::Delux.Domain.Technician.Technician(_technicianData);
            _technicians.Add(te).GetAwaiter();
            AddRandomTechnicians();

            Obj = new TestClass(_appointments, _clients, _treatments, _technicians);
        }

        private void AddRandomClients()
        {
            for (var i = 0; i < GetRandom.UInt8(3, 10); i++)
            {
                var d = GetRandom.Object<ClientData>();
                var c = new global::Delux.Domain.Client.Client(d);
                _clients.Add(c).GetAwaiter();
            }
        }

        private void AddRandomTreatments()
        {
            for (var i = 0; i < GetRandom.UInt8(3, 10); i++)
            {
                var d = GetRandom.Object<TreatmentData>();
                var tr = new global::Delux.Domain.Treatment.Treatment(d);
                _treatments.Add(tr).GetAwaiter();
            }
        }

        private void AddRandomTechnicians()
        {
            for (var i = 0; i < GetRandom.UInt8(3, 10); i++)
            {
                var d = GetRandom.Object<TechnicianData>();
                var te = new global::Delux.Domain.Technician.Technician(d);
                _technicians.Add(te).GetAwaiter();
            }
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<AppointmentView>();
            Obj.Item = item;
            Assert.AreEqual(item.GetId(), Obj.ItemId);
            Obj.Item = null;
            Assert.AreEqual(string.Empty, Obj.ItemId);
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

        [TestMethod]
        public void GetClientNameTest()
        {
            var name = Obj.GetClientName(_clientData.Id);
            Assert.AreEqual(_clientData.Name, name);
        }

        [TestMethod]
        public void ClientsTest()
        {
            var list = _clients.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, Obj.Clients.Count());
        }

        [TestMethod]
        public void GetTreatmentNameTest()
        {
            var name = Obj.GetTreatmentName(_treatmentData.Id);
            Assert.AreEqual(_treatmentData.Name, name);
        }

        [TestMethod]
        public void TreatmentsTest()
        {
            var list = _treatments.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, Obj.Treatments.Count());
        }

        [TestMethod]
        public void GetTechnicianNameTest()
        {
            var name = Obj.GetTechnicianName(_technicianData.Id);
            Assert.AreEqual(_technicianData.Name, name);
        }

        [TestMethod]
        public void TechniciansTest()
        {
            var list = _technicians.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, Obj.Technicians.Count());
        }
    }
}
