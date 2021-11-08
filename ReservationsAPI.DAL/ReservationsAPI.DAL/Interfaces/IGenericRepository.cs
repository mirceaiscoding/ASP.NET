using System;
using System.Collections.Generic;

namespace ReservationsAPI.DAL.Interfaces
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(long id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
