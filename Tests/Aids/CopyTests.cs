using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Delux.Data.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class CopyTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(Copy);
        }

        [TestMethod]
        public void MembersTest()
        {
            var x = GetRandom.Object<TreatmentData>();
            var y = GetRandom.Object<TreatmentData>();
            TestArePropertiesNotEqual(x, y);
            Copy.Members(x, y);
            TestArePropertyValuesEqual(x, y);
        }
    }
}
