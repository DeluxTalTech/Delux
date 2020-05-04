﻿using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Treatment;
using Delux.Domain.Common;
using Delux.Domain.Technician;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Domain.Technician
{
    [TestClass]
   public class HairdresserTests : SealedClassTests<Hairdresser, Entity<HairTreatmentData>>
    {
    }
}
