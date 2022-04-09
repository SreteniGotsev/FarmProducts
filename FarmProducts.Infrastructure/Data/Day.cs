namespace FarmProducts.Infrastructure.Data
{
    public class Day
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public ICollection<Farm> Farms { get; set; }
    }
}
