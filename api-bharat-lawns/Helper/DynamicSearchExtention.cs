using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
namespace api_bharat_lawns.Helper
{
	public static class DynamicSearchExtention
	{
        public static IQueryable<T> WhereContains<T>(this IQueryable<T> source, string propertyPath, string searchValue)
        {
            var properties = propertyPath.Split('.');
            var parameter = Expression.Parameter(typeof(T), "x");

            var property = (Expression)parameter;
            foreach (var propName in properties)
            {
                property = Expression.PropertyOrField(property, propName);
            }

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var containsExpression = Expression.Call(property, containsMethod, Expression.Constant(searchValue, typeof(string)));

            var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);

            return source.Where(lambda);
        }

    }

}

