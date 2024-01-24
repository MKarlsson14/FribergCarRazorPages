using FibergCarRazorPages.Models;

namespace FibergCarRazorPages.Data
{
    public class CarRepository : GenericRepository<Car>
    {
        private readonly ApplicationDbContext context;

        public CarRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override IEnumerable<Car> GetAll()
        {
            return context.Cars.OrderBy(s => s.Brand);

        }
        public override Car GetById(int id)
        {
            return context.Cars.FirstOrDefault(s => s.CarId == id);
        }

        public override void Add(Car car)
        {
            context.Cars.Add(car); context.SaveChanges();
        }

        public override void Edit(Car car)
        {
            context.Cars.Update(car); context.SaveChanges();
        }
        public override void Delete(Car car)
        {
            context.Cars.Remove(car); context.SaveChanges();
        }

    }
}
