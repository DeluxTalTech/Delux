using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        private const string Assembly = "Delux.Infra";

        protected override string Namespace(string name)
        {
            return $"{Assembly}.{name}";
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
            IsAllTested(base.Namespace("Infra"));
        }
    }
}
