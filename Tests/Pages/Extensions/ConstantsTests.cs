using Delux.Pages.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Extensions
{
    [TestClass]
    public class ConstantsTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize() => Type = typeof(Constants);
        
        [TestMethod] public void UnspecifiedTest() => Assert.AreEqual( "Täpsustamata", Constants.Unspecified);
        [TestMethod] public void CreateNewLinkTitleTest() => Assert.AreEqual("Loo uus", Constants.CreateNewLinkTitle);
        [TestMethod] public void EditLinkTitleTest() => Assert.AreEqual("Muuda", Constants.EditLinkTitle);
        [TestMethod] public void DetailsLinkTitleTest() => Assert.AreEqual("Detailid", Constants.DetailsLinkTitle);
        [TestMethod] public void DeleteLinkTitleTest() => Assert.AreEqual("Kustuta", Constants.DeleteLinkTitle);
        [TestMethod] public void SelectLinkTitleTest() => Assert.AreEqual("Vali", Constants.SelectLinkTitle);
        [TestMethod] public void TechniciansPageTitleTest() => Assert.AreEqual("Tehnikud", Constants.TechniciansPageTitle);
        [TestMethod] public void TreatmentsPageTitleTest() => Assert.AreEqual("Hooldused", Constants.TreatmentsPageTitle);
        [TestMethod] public void ClientsPageTitleTest() => Assert.AreEqual("Kliendid", Constants.ClientsPageTitle);
        [TestMethod] public void AppointmentsPageTitleTest() => Assert.AreEqual("Broneeringud", Constants.AppointmentsPageTitle);
    }
}
 