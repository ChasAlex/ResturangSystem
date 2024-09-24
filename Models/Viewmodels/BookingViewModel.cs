namespace ResturangSystem.Models.Viewmodels
{
    public class BookingViewModel
    {
        public int BokningId { get; set; }
        public int Antal { get; set; }
        public string Namn { get; set; }
        public DateOnly Datum { get; set; }
        public int BordNummer { get; set; }
    }
}
