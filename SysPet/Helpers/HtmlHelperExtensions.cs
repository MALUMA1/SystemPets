using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using SysPet.Helpers;
using System.Web.Mvc;
using System.Text;

public static class HtmlHelperExtensions
{
    public static IHtmlContent DisplayPasswordFor<TModel, TResult>(
        this IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TResult>> expression)
    {
        //var metadata = htmlHelper.ViewData.ModelMetadata.Properties.Single(x => x.PropertyName == ExpressionHelper.GetExpressionText(expression));

        var properties = htmlHelper.ViewData.Model.GetType();
        var metadata = htmlHelper.ViewData;


        //if (password != null)
        //{
        //    var html = new StringBuilder();

        //    foreach (char c in password)
        //    {
        //        html.Append('*');
        //    }

        //    return new HtmlString(html.ToString());
        //}

        return htmlHelper.DisplayFor(expression);
    }
}
