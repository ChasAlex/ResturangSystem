using System.ComponentModel.DataAnnotations;

namespace ResturangSystem.Models
{
    public class Restaurang
    {
        [Key]
        public int RestaurangId { get; set; }
        public string Namn { get; set; }

        public ICollection<Bord> Bord { get; set; }
        public ICollection<Meny> Meny { get; set; }
    }
}
