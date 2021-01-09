using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Data.Repositoty
{
    public abstract class SkinetRepository<T> : ISkinetRepository<T> where T : Entity
    {
        protected readonly SkinetContext _context;

        public SkinetRepository(SkinetContext context)
        {
            _context = context;
        }
        public async Task Create(T entity)
        {
            _context.Set<T>().Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var list = await GetAll();

            return list.FirstOrDefault(e => e.Id == id);
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}