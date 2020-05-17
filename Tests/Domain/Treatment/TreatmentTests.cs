using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Treatment;
using Delux.Domain.Common;
using Delux.Domain.Treatment;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Domain.Treatment
{
    [TestClass]
    public class TreatmentTests : SealedClassTests <global::Delux.Domain.Treatment.Treatment, Entity<TreatmentData>>
    {
    }
}
