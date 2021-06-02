namespace DM.Api.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        int Create(TEntity entity, string nombreId);
        void Update(TEntity entity);
        IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
    }
}
