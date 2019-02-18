using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Piranha.Extend.Fields;
using System;
using System.Linq.Expressions;
using Piranha.Extend;

namespace Fase.Web.Extensions
{
    public static class ManagerExtensions
    {
        public static string FieldIdFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> fieldExpression, string propertyName) where TResult: IField
        {
            var modelMetaData = ExpressionMetadataProvider.FromLambdaExpression(fieldExpression, htmlHelper.ViewData, htmlHelper.ViewData.ModelMetadata);
            var prefix = htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix
                .Replace("[", "_").Replace("]", "_").Replace(".", "_");

            return $"{prefix}_{modelMetaData.Metadata.PropertyName}_{propertyName}";
        }
    }
}
