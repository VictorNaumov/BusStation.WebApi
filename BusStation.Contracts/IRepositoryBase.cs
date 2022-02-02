using System;
using System.Linq;
using System.Linq.Expressions;

namespace BusStation.Contracts
{
    public interface IRepositoryBase<T>
    {
        public IQueryable<T> FindAll(bool trackChanges);
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        public void Create(T entity);
        public void Update(T entity);
    }
}
