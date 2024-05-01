using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techbuzzers_bank.Models
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("UserDetails")]
        public int senderId { get; set; }
        [Required]
        [ForeignKey("UserDetails")]
        public int receiverId { get; set; }
        [Required]
        public float amount {  get; set; }
        [Required]
        public DateTime dateTime { get; set; }
        
        public string status { get; set; } = "Pending";
    }
}
