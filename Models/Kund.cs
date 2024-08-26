using System.ComponentModel.DataAnnotations;

namespace ResturangSystem.Models
{
    public class Kund
    {
        [Key]
        public int KundId { get; set; }
        public string Namn { get; set; }
        public string Email { get; set; }

        public ICollection<Bokning> Bokningar { get; set; }
    }
}
