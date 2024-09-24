namespace ResturangSystem.Models.DTO
{
    public class UpdateBokningDTO
    {
        public int BokningId { get; set; }
        public int Antal { get; set; }
        public int Bordnummer { get; set; }
        public string Namn { get; set; }
        public DateTime Datum { get; set; }
        
    }
}
