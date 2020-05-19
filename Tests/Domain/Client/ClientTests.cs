using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Client;
using Delux.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Domain.Client
{
    [TestClass]
    public class ClientTests:SealedClassTests<global::Delux.Domain.Client.Client, Entity<ClientData>>
    {
    }
}
