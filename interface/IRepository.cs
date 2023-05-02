namespace CelilCavus.Interface
{
    public interface IRepository<T> where T : class,new()
    {
        void Add(T item);
        void Update(T item);

        void Delete(T item);

        Task<List<T>> GetList();

        Task<T> GetById(int id);        
    }
}