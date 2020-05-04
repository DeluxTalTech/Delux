using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Domain
{
    [TestClass]
    public class IsDomainTested: AssemblyTests
    {
        private const string Assembly = "Delux.Domain";

        protected override string Namespace(string name)
        {
            return $"{Assembly}.{name}";
        }

        [TestMethod]
        public void IsCommonTested()
        {
            IsAllTested(Assembly, Namespace("Common"));
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
            IsAllTested(base.Namespace("Domain"));
        }
    }
}
