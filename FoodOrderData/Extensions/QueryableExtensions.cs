using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FoodOrder.Model;

namespace FoodOrderData.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj,
            Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (string.IsNullOrEmpty(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                return query;
            
            return queryObj.IsSortAscending ? query.OrderBy(columnsMap[queryObj.SortBy]) : query.OrderByDescending(columnsMap[queryObj.SortBy]);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0) queryObj.Page = 1;
            if (queryObj.PageSize <= 0) queryObj.PageSize = 10;

            return query.Skip((queryObj.Page - 1) + queryObj.PageSize).Take(queryObj.PageSize);
        }
    }
}
