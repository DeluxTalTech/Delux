﻿using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Delux.Pages.Extensions 
{

    public static class EditControlsForEnumHtmlExtension 
    {

        public static IHtmlContent EditControlsForEnum<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression) 
        {
            
            var selectList = new SelectList(Enum.GetNames(typeof(TResult)));
            
            var htmlStrings = EditControlsForEnumHtmlExtension.HtmlStrings(htmlHelper, expression, selectList);

            return new HtmlContentBuilder(htmlStrings);
        }

        private static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, SelectList selectList) 
        {
            return new List<object> 
            {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new {@class = "text-dark"}),
                htmlHelper.DropDownListFor(expression, selectList, new {@class = "form-control"}),
                htmlHelper.ValidationMessageFor(expression, "", new {@class = "text-danger"}),
                new HtmlString("</div>")
            };
        }

    }

}