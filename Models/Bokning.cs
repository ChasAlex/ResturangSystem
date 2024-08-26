using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturangSystem.Models
{

    public class Bokning
    {
        [Key]
        public int BokningId { get; set; }
        public DateTime Datum { get; set; }
        public int Antal { get; set; }

        [ForeignKey("Kund")]
        public int KundId { get; set; }
        public Kund Kund { get; set; }

        [ForeignKey("Bord")]
        public int BordId { get; set; }
        public Bord Bord { get; set; }
    }
}
