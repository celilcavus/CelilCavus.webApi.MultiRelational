using CelilCavus.Interface;
using CelilCavus.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CelilCavus.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T item) =>  _context.Set<T>().Add(item);

        public void Delete(T item) => _context.Set<T>().Remove(item);
        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<List<T>> GetList() => await _context.Set<T>().AsNoTracking().ToListAsync();
        public void Update(T item) => _context.Set<T>().Update(item);

      
    }
}