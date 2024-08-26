namespace ResturangSystem.Models.DTO
{
    public class AvailableBokningDTO
    {
        public int BordsNummer { get; set; }
        public IEnumerable<DateTime> Datum { get; set; } 
    }
}
