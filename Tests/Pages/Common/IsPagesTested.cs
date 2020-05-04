using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Common
{
    [TestClass]
    public class IsPagesTested : AssemblyTests
    {
        private const string Assembly = "Delux.Pages";

        protected override string Namespace(string name)
        {
            return $"{Assembly}.{name}";
        }

        [TestMethod]
        public void IsExtensionsTested()
        {
            IsAllTested(Assembly, Namespace("Extensions"));
        }

        [TestMethod]
        public void IsTechnicianTested()
        {
            IsAllTested(Assembly, Namespace("Technician"));
        }

        [TestMethod]
        public void IsTreatmentTested()
        {
            IsAllTested(Assembly, Namespace("Treatment"));
        }

        [TestMethod]
        public void IsTested()
        {
            IsAllTested(base.Namespace("Pages"));
        }
    }
}
