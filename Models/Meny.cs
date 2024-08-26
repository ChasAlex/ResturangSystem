using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturangSystem.Models
{
    public class Meny
    {
        [Key]
        public int MenyId { get; set; }
        public string Namn { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Pris { get; set; }
        public bool Tillgänglig { get; set; }

        [ForeignKey("Restaurang")]
        public int RestaurangId { get; set; }
        public Restaurang Restaurang { get; set; }
    }
}
