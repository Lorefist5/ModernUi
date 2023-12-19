using Microsoft.EntityFrameworkCore;
using ModernUi.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModernUi.Data.Repositories.ORM
{
    public class GenericRepositoryORM<T> : IGeneric<T> where T : class
    {
        protected ApplicationDbContext _db;
        internal DbSet<T> dbset;
        public GenericRepositoryORM(ApplicationDbContext db)
        {
            _db = db;
            dbset = _db.Set<T>();
        }
        public async Task Add(T entity)
        {
            await dbset.AddAsync(entity);

        }

        public async Task Delete(T entity)
        {
            await Task.FromResult(dbset.Remove(entity));
        }



        public async Task<IEnumerable<T>> GetAll()
        {
            List<T> entities = await dbset.ToListAsync();
            return entities;
        }

        public async Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            T? results = await query.Where(filter).FirstOrDefaultAsync();
            return results;
        }

        public async Task<IEnumerable<T>> GetFiltered(Expression<Func<T, bool>> filter)
        {
            List<T> entities = await dbset.Where(filter).ToListAsync();
            return entities;
        }

    }
}