using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Skynet.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SkynetContext _context;

        public Repository(SkynetContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<T> items)
        {
            await _context.Set<T>().AddRangeAsync(items);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task RemoveAsync(T item)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Remove(item);
            });
        }

        public async Task RemoveRangeAsync(IEnumerable<T> items)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().RemoveRange(items);
            });
        }

        public async Task UpdateAsync(T item)
        {
            await Task.Run(() =>
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.Set<T>().Update(item);
            });
        }
    }

    public interface IRepository<T>
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T item);
        Task AddRangeAsync(IEnumerable<T> items);

        Task RemoveAsync(T item);
        Task RemoveRangeAsync(IEnumerable<T> items);

        Task UpdateAsync(T item);
    }
}
