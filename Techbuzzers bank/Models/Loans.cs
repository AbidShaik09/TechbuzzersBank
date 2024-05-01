using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techbuzzers_bank.Models
{
    public class Loans
    {
        [Key]
        public String id {  get; set; }
        
        [ForeignKey(nameof(Account))]
        public required String accountId { get; set; }
        [Required]
        public string type { get; set; } //Personal / Gold / Education

        public DateTime timestamp { get; set; }
        [Required]
        public float amount { get; set; }
        [Required]
        public int roi { get; set; }
        [Required]
        public int tenure { get; set; }
        [Required]
        public float due { get; set; }

        public List<Payables> payables { get; set; }
        public String status { get; set; } = "Open";
    }
}
