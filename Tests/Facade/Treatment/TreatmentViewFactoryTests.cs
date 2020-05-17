using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Facade.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Treatment
{
    [TestClass]
    public class TreatmentViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(TreatmentViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<TreatmentView>();
            var data = TreatmentViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<TreatmentData>();
            var view = TreatmentViewFactory.Create(new global::Delux.Domain.Treatment.Treatment(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}
