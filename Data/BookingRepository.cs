using FibergCarRazorPages.Models;

namespace FibergCarRazorPages.Data
{
    public class BookingRepository : GenericRepository<Booking>
    {
        private readonly ApplicationDbContext context;

        public BookingRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        //Denna method tar in id från specifik customer och skriver ut alla ordrar som den kunden har
        public IEnumerable<Booking> GetOrdersById(int id)
        {
            return context.Bookings.Where(s => s.CustomerId == id);
        }

        public override void Add(Booking booking)
        {
            context.Bookings.Add(booking); context.SaveChanges();
        }

        public override void Delete(Booking booking)
        {
            context.Bookings.Remove(booking); context.SaveChanges();
        }

        public override IEnumerable<Booking> GetAll()
        {
            return context.Bookings.OrderBy(s => s.CustomerId);
        }

        public override Booking GetById(int id)
        {
            return context.Bookings.FirstOrDefault(s => s.BookingId == id);
        }
    }
}
