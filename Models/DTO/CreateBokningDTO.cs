namespace ResturangSystem.Models.DTO
{
    public class CreateBokningDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Antal { get; set; }
        public int Bordsnummer { get; set; }

        public DateTime Datum { get; set; }
         



    }
}
