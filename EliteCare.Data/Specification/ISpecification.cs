using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.Specification
{
    public interface ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>> Orderby { get; set; }
        public Expression<Func<T, object>> OrderbyDecs { get; set; }

        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagination { get; set; }
        public void AddInclude(Expression<Func<T, object>> includeExpression);





    }
}
