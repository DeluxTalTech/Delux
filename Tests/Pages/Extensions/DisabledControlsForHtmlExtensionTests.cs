using System.Collections.Generic;
using Delux.Facade.Technician;
using Delux.Pages.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Extensions
{
    [TestClass]
    public class DisabledControlsForHtmlExtensionTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize() => Type = typeof(DisabledControlsForHtmlExtension);

        [TestMethod]
        public void DisabledControlsForTest()
        {
            var obj = new HtmlHelperMock<BeauticianView>().DisabledControlsFor(x => x.Id);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> { "<div", "<fieldset disabled>", "LabelFor", "EditorFor", "ValidationMessageFor", "</fieldset>", "</div" };
            var actual = DisabledControlsForHtmlExtension.HtmlStrings(new HtmlHelperMock<BeauticianView>(), x => x.Name);
            TestHtml.Strings(actual, expected);
        }
    }
}
