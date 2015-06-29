using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace UI.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, MvcHtmlString editor)
        {
            var formGroup = new TagBuilder("div");
            formGroup.AddCssClass("pure-control-group");

            var label = htmlHelper.LabelFor(expression);

            var validationMessage = new TagBuilder("div");
            validationMessage.AddCssClass("validation-error");
            validationMessage.InnerHtml = htmlHelper.ValidationMessageFor(expression).ToString();

            formGroup.InnerHtml = label + "\n" + editor + "\n" + validationMessage;
            return new MvcHtmlString(formGroup.ToString());
        }
    }
}
