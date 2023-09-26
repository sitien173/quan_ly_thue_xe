using System.Linq.Expressions;

namespace CarRentalManagement.Extensions;

public static class QueryableExtension
{
    public static IQueryable<T> AddWhereClause<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> predicate, bool condition)
    {
        return condition ? queryable.Where(predicate) : queryable;
    }
}