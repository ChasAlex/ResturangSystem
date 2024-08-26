using ResturangSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResturangSystem.Models.DTO
{
    public class BokningDTO
    {
        public int BokningId { get; set; }
        public int Antal { get; set; }
        public int KundId { get; set; }
        public int BordId { get; set; }
        public DateTime Datetime { get; set; }
    }
}
