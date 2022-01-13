using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.DAL.Interfaces
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetQueryable();

        IEnumerable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();

        TEntity GetByID(object id);
        Task<TEntity> GetByIdAsync(object id);

        void Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);

        void Delete(TEntity entity);
        void Delete(object id);

        void Update(TEntity entity);
    }
}
