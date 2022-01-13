using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.DAL.Interfaces;

namespace ReservationsAPI.DAL.Repositories
{
    public class GenericRepository <TEntity> : IGenericRepository <TEntity> where TEntity : class
    {
        internal ReservationsContext _context;
        internal DbSet<TEntity> entities;

        public GenericRepository(ReservationsContext context)
        {
            this._context = context;
            entities = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetQueryable()
        {
            return entities;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return entities;
        }

        public virtual TEntity GetByID(object id)
        {
            return entities.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = entities.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                entities.Attach(entityToDelete);
            }
            entities.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            entities.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await entities.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
