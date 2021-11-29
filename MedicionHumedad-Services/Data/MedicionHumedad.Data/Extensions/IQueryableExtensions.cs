using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MedicionHumedad.Data.Extensions
{
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderBy(ToLambda<T>(propertyName));
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderByDescending(ToLambda<T>(propertyName));
        }


        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }

        public static bool IsIn<T>(this T keyObject, params T[] collection)
        {
            return collection.Contains(keyObject);
        }

        public static bool IsIn<T>(this T keyObject, IEnumerable<T> collection)
        {
            return collection.Contains(keyObject);
        }

        public static bool IsNotIn<T>(this T keyObject, params T[] collection)
        {
            return keyObject.IsIn(collection) == false;
        }

        public static bool IsNotIn<T>(this T keyObject, IEnumerable<T> collection)
        {
            return keyObject.IsIn(collection) == false;
        }

        public static Expression<Func<T, bool>> BuildPredicate<T>(string propertyName, string comparison, object value)
        {
            var parameter = Expression.Parameter(typeof(T));
            var left = propertyName.Split('.').Aggregate((Expression)parameter, Expression.PropertyOrField);
            var body = MakeComparison(left, comparison, value);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        static Expression MakeComparison(Expression left, string comparison, object value)
        {
            var constant = Expression.Constant(value, left.Type);
            switch (comparison)
            {
                case "==":
                    return Expression.MakeBinary(ExpressionType.Equal, left, constant);
                case "!=":
                    return Expression.MakeBinary(ExpressionType.NotEqual, left, constant);
                case ">":
                    return Expression.MakeBinary(ExpressionType.GreaterThan, left, constant);
                case ">=":
                    return Expression.MakeBinary(ExpressionType.GreaterThanOrEqual, left, constant);
                case "<":
                    return Expression.MakeBinary(ExpressionType.LessThan, left, constant);
                case "<=":
                    return Expression.MakeBinary(ExpressionType.LessThanOrEqual, left, constant);
                case "Contains":
                case "StartsWith":
                case "EndsWith":
                    if (value is string)
                    {
                        return Expression.Call(left, comparison, Type.EmptyTypes, constant);
                    }
                    throw new NotSupportedException($"Comparison operator '{comparison}' only supported on string.");
                default:
                    throw new NotSupportedException($"Invalid comparison operator '{comparison}'.");
            }
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, string comparison, string value)
        {
            return source.Where(BuildPredicate<T>(propertyName, comparison, value));
        }

        public static Tuple<IQueryable<T>, int> Paginated<T>(this IQueryable<T> source, int currentPage, int pageSize, string sortOn, string sortDirection)
        {
            int count = source.Count();

            if (!string.IsNullOrEmpty(sortOn))
            {
                if (sortDirection.ToUpper() == "ASC")
                {
                    source = source.OrderBy(sortOn);
                }
                else
                {
                    source = source.OrderByDescending(sortOn);
                }
            }

            source = source.Skip((currentPage - 1) * pageSize).Take(pageSize);

            return new Tuple<IQueryable<T>, int>(source, count);
        }
    }
}