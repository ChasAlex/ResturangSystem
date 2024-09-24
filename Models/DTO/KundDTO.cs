namespace ResturangSystem.Models.DTO
{
    public class KundDTO
    {
        public int? KundId { get; set; }
        public string Namn { get; set; }
        public string Email { get; set; }

        public ICollection<Bokning>? Bokningar { get; set; } = new List<Bokning>();
    }
}
