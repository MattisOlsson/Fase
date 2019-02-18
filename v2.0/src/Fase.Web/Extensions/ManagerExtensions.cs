using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Piranha.Extend.Fields;
using System;
using System.Linq.Expressions;

namespace Fase.Web.Extensions
{
    public static class ManagerExtensions
    {
        public static string FieldIdFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
        {
            var modelMetaData = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.ViewData.ModelMetadata);
            var prefix = htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix
                .Replace("[", "_").Replace("]", "_").Replace(".", "_");

            if (typeof(MediaFieldBase<>).IsAssignableFrom(modelMetaData.ModelType))
            {
                return $"{prefix}_{modelMetaData.Metadata.PropertyName}_Id";
            }

            return $"{prefix}_{modelMetaData.Metadata.PropertyName}_Value";
        }
    }
}
