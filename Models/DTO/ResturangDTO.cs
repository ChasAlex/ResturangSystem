namespace ResturangSystem.Models.DTO
{
    public class ResturangDTO
    {
        public int RestaurangId { get; set; }
        public string Namn { get; set; }

        public ICollection<Bord> Bord { get; set; } = new List<Bord>();
        public ICollection<Meny> Meny { get; set; } = new List<Meny>();
    }
}
