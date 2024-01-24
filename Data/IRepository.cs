namespace FibergCarRazorPages.Data
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Edit(T entity);
        IEnumerable<T> GetAll();
        void Delete(T entity);
        T GetById(int id);
    }
}
