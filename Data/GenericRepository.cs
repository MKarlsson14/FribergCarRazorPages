namespace FibergCarRazorPages.Data
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public virtual void Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return context.Find<T>(id);

        }

        public virtual void Edit(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
