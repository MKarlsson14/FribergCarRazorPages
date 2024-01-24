using FibergCarRazorPages.Models;

namespace FibergCarRazorPages.Data
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        private readonly ApplicationDbContext context;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override void Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public override void Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public override void Edit(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }

        public override IEnumerable<Customer> GetAll()
        {
            return context.Customers.OrderBy(s => s.CustomerName);
        }

        public override Customer GetById(int id)
        {
            return context.Customers.FirstOrDefault(s => s.CustomerId == id);
        }
    }
}
