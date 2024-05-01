using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techbuzzers_bank.Models
{
    public class Transactions
    {
        [Key]
        public string id { get; set; }
        [Required]
        [ForeignKey ( nameof(UserDetails))]
        public int debitId { get; set; }
        [Required]
        [ForeignKey(nameof(UserDetails))]
        public int creditId { get; set; }
        [Required]
        public float amount {  get; set; }
        [Required]
        public DateTime timestamp { get; set; }
        
        public string status { get; set; } = "Pending";
    }
}
