using CelilCavus.Interface;
using CelilCavus.Models.Contexts;
using CelilCavus.Repository;
using Microsoft.EntityFrameworkCore;

namespace CelilCavus.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly DbContext _context;

        public Uow(DbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
           return new GenericRepository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}