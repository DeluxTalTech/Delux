using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Delux.Pages.Extensions 
{
    public static class WebPageTitleForHtmlExtension 
    {

        public static IHtmlContent WebPageTitleFor(this IHtmlHelper htmlHelper, string title) 
        {
            htmlHelper.ViewData["Title"] = title;
            var htmlStrings = new List<object> 
            {
                new HtmlString("<h1>"),
                new HtmlString(title),
                new HtmlString("</h1>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }

    }
}
