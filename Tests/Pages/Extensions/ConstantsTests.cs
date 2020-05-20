using Delux.Pages.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Extensions
{
    [TestClass]
    public class ConstantsTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize() => Type = typeof(Constants);
        
        [TestMethod] public void UnspecifiedTest() => Assert.AreEqual( "Unspecified", Constants.Unspecified);
        [TestMethod] public void CreateNewLinkTitleTest() => Assert.AreEqual("Create New", Constants.CreateNewLinkTitle);
        [TestMethod] public void EditLinkTitleTest() => Assert.AreEqual("Edit", Constants.EditLinkTitle);
        [TestMethod] public void DetailsLinkTitleTest() => Assert.AreEqual("Details", Constants.DetailsLinkTitle);
        [TestMethod] public void DeleteLinkTitleTest() => Assert.AreEqual("Delete", Constants.DeleteLinkTitle);
        [TestMethod] public void SelectLinkTitleTest() => Assert.AreEqual("Select", Constants.SelectLinkTitle);
        [TestMethod] public void TechniciansPageTitleTest() => Assert.AreEqual("Technicians", Constants.TechniciansPageTitle);
        [TestMethod] public void TreatmentsPageTitleTest() => Assert.AreEqual("Treatments", Constants.TreatmentsPageTitle);
        [TestMethod] public void ClientsPageTitleTest() => Assert.AreEqual("Clients", Constants.ClientsPageTitle);
        [TestMethod] public void AppointmentsPageTitleTest() => Assert.AreEqual("Appointments", Constants.AppointmentsPageTitle);
    }
}
 