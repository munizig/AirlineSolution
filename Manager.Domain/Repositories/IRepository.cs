using System;
using System.Linq;

namespace Manager.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Dispose();
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Remove(Guid id);
        int SaveChanges();
        void Update(TEntity obj);
    }
}