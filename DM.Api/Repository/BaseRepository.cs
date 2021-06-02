namespace DM.Api.Repository
{
    using DM.Api.BaseDeDatos.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected CrediAgilContext Db = new CrediAgilContext();
        protected DbSet<TEntity> Data;
        public BaseRepository(CrediAgilContext _Db)
        {
            Db = _Db;
            Data = Db.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Data;
        }
        public int Create(TEntity entity,string nombreId)
        {
            Data.Add(entity);
            Db.SaveChanges();
            var IdProperty = entity.GetType().GetProperty(nombreId).GetValue(entity, null);
            int id=  (int)IdProperty;
            return id;

        }
        public void Update(TEntity entity)
        {
            Data.Attach(entity);
            var entry = Db.Entry(entity);
            entry.State = EntityState.Modified;
            Db.SaveChanges();
        }
        public IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = Data.AsNoTracking().Where(predicate);
            return query;
        }
        public void Delete(TEntity entity)
        {
            Data.Remove(entity);
            Db.SaveChanges();
        }
    }
}
