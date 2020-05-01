using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests
{
    public abstract class AbstractClassTests<TClass, TBaseClass> : BaseClassTests<TClass,TBaseClass>
    {
        [TestMethod]
        public void IsAbstract()
        {
            Assert.IsTrue(Type.IsAbstract);
        }
    }
}