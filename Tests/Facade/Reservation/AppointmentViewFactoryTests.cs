using Delux.Aids;
using Delux.Data.Reservation;
using Delux.Domain.Reservation;
using Delux.Facade.Reservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Reservation
{
    [TestClass]
    public class AppointmentViewFactoryTests:BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(AppointmentViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<AppointmentView>();
            var data = AppointmentViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<AppointmentData>();
            var view = AppointmentViewFactory.Create(new Appointment(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}
