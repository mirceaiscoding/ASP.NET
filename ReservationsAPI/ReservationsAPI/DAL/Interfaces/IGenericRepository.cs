using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservationsAPI.DAL.Interfaces
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetQueryable();
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(long id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
