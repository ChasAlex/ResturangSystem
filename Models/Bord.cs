using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturangSystem.Models
{
    public class Bord
    {
        [Key]
        public int BordId { get; set; }
        public int Bordsnummer { get; set; }
        public int Platser { get; set; }
        public bool BoolBokad { get; set; }

        [ForeignKey("Restaurang")]
        public int RestaurangId { get; set; }
        public Restaurang Restaurang { get; set; }

        public ICollection<Bokning> Bokningar { get; set; }
    }
}
