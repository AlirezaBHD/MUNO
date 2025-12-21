using System.Linq.Expressions;

namespace Muno.Application.Common.Extensions;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> And<T>(
        this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ReplaceExpressionVisitor(left.Parameters[0], parameter);
        var leftBody = leftVisitor.Visit(left.Body);

        var rightVisitor = new ReplaceExpressionVisitor(right.Parameters[0], parameter);
        var rightBody = rightVisitor.Visit(right.Body);

        return Expression.Lambda<Func<T, bool>>(
            Expression.AndAlso(leftBody!, rightBody!), parameter);
    }

    private class ReplaceExpressionVisitor(Expression oldValue, Expression newValue) : ExpressionVisitor
    {
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == oldValue ? newValue : base.VisitParameter(node);
        }
    }
}