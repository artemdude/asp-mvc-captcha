using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcCaptchaProject
{
    public static class htmlHelpers
    {
        public static IHtmlString CaptchaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
           string actionName = "GetCaptcha")
        {
            var image = new TagBuilder("img");
            image.MergeAttribute("src", UrlHelper.GenerateUrl(null, actionName, null, null,
                htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true));
            image.MergeAttribute("border", "0");
            image.MergeAttribute("class", "captcha-img");

            var textBox = htmlHelper.TextBoxFor(expression, new { @class = "form-control" });

            return new HtmlString(
                image.ToString(TagRenderMode.SelfClosing) +
                textBox + Environment.NewLine);
        }
    }
}