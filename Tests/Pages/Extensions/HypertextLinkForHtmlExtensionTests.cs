﻿using Delux.Pages.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Extensions
{
    [TestClass]
    public class HypertextLinkForHtmlExtensionTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize() => Type = typeof(HypertextLinkForHtmlExtension);

        [TestMethod]
        public void HypertextLinkForTest()
        {
            Assert.Inconclusive();
        }
    }
}