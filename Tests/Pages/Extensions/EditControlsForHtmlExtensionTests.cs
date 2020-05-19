using System.Collections.Generic;
using Delux.Facade.Treatment;
using Delux.Pages.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Extensions
{
    [TestClass]
    public class EditControlsForHtmlExtensionTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize() => Type = typeof(EditControlsForHtmlExtension);

        [TestMethod]
        public void EditControlsForTest()
        {
            var obj = new HtmlHelperMock<TreatmentView>().EditControlsFor(x => x.Id);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> {"<div", "LabelFor", "EditorFor", "ValidationMessageFor", "</div" };
            var actual = EditControlsForHtmlExtension.HtmlStrings(new HtmlHelperMock<TreatmentView>(), x => x.Name);
            TestHtml.Strings(actual, expected);
        }
    }
}