using FibergCarRazorPages.Models;
using FribergCarRazorPages.Data;
using Microsoft.EntityFrameworkCore;

namespace FibergCarRazorPages.Data
{
    public class BookingRepository : GenericRepository<Booking>, IBooking
    {
        private readonly ApplicationDbContext context;

        public BookingRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        //Denna method tar in id från specifik customer och skriver ut alla ordrar som den kunden har
        public IEnumerable<Booking> GetOrdersById(int id)
        {
            return context.Bookings.Include(s=>s.Customer).Include(s=>s.Car).Where(s => s.CustomerId == id);
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
            return context.Bookings.Include(s => s.Car).Include(s=>s.Customer).OrderBy(s => s.CustomerId);
        }

        public override Booking GetById(int id)
        {
            return context.Bookings.FirstOrDefault(s => s.BookingId == id);
        }
    }
}
