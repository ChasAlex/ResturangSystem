using System.ComponentModel.DataAnnotations.Schema;

namespace ResturangSystem.Models.DTO
{
    public class MenyDTO
    {
        public int MenyId { get; set; }
        public string Namn { get; set; }
        public decimal Pris { get; set; }
        public bool Tillgänglig { get; set; }
        public Restaurang Restaurang { get; set; }
    }
}
