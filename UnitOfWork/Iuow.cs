using CelilCavus.Interface;

namespace CelilCavus.UnitOfWork
{
    public interface IUow
    {
        void SaveChanges();

        IRepository<T> GetRepository<T>() where T : class,new();
    }
}