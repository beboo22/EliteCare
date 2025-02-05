using EliteCare.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteCare.Data.Specification
{
    public static class SpecificationEvaluation<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> Innerquery, ISpecification<T> specification)
        {
            var query = Innerquery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.Orderby != null)
            {
                query = query.OrderBy(specification.Orderby);
            }

            if(specification.OrderbyDecs != null)
            {
                query = query.OrderByDescending(specification.OrderbyDecs);
            }

            if(specification.IsPagination) query = query.Skip(specification.Skip).Take(specification.Take);


            if (specification.Includes.Count() > 0)
            {
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
