namespace FibergCarRazorPages.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int Price { get; set; }

        public string? Picture1 { get; set; }
        public string? Picture2 { get; set; }
    }
}
