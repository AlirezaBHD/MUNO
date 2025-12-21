using System.Linq.Expressions;
using Muno.Application.Common.Extensions;
using Muno.Domain.Interfaces.Specifications;

namespace Muno.Application.Common.Specifications;

public abstract class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public BaseSpecification()
    {
    }


    public Expression<Func<T, bool>>? Criteria { get; protected set; }

    public List<Expression<Func<T, object>>> Includes { get; } = new();

    public List<string> IncludeStrings { get; } = new();

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; }
    public bool AsNoTracking { get; private set; }

    protected void AddCriteria(Expression<Func<T, bool>> newCriteria)
    {
        if (Criteria == null)
        {
            Criteria = newCriteria;
        }
        else
        {
            Criteria = Criteria.And(newCriteria);
        }
    }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }

    protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }

    protected void ApplyNoTracking()
    {
        AsNoTracking = true;
    }
}