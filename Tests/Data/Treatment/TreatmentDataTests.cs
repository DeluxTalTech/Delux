using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Common;
using Delux.Data.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Treatment
{
    [TestClass]
    public class TreatmentDataTests : SealedClassTests<TreatmentData, DurationData>
    {
        [TestMethod]
        public void TreatmentTypeIdTest()
        {
            IsNullableProperty(() => Obj.TreatmentTypeId, x => Obj.TreatmentTypeId = x);
        }
    }
}
