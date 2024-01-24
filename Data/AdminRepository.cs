using FibergCarRazorPages.Models;

namespace FibergCarRazorPages.Data
{
    public class AdminRepository<T> : GenericRepository<Admin>
    {
        private readonly ApplicationDbContext context;

        public AdminRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        //Gör separata metoder för all CRUD, istället för generics
        public void Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public void Edit(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
