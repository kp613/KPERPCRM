using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository
{
    public class Repository<TDbContext> : IRepository where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public Repository(TDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            this._context.Set<T>().Add(entity);
            _ = await this._context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            this._context.Set<T>().Remove(entity);

            _ = await this._context.SaveChangesAsync();
        }
        public async Task<List<T>> SelectAll<T>() where T : class
        {
            return await this._context.Set<T>().ToListAsync();
        }

        public async Task<T> SelectById<T>(long id) where T : class
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            this._context.Set<T>().Update(entity);

            _ = await this._context.SaveChangesAsync();
        }
    }
}
