using System.ComponentModel.DataAnnotations.Schema;

namespace ResturangSystem.Models.DTO
{
    public class BordDTO
    {
        
        public int Bordsnummer { get; set; }
        public int Platser { get; set; }
        public bool BoolBokad { get; set; }
        public int RestaurangId { get; set; }

       



    }
}
