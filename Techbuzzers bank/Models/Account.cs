using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techbuzzers_bank.Models
{
    public class Account
    {
        [Key]
       
        public long Id { get; set; }


        [ForeignKey(nameof(UserDetails))]
        public long UserId { get; set; }


        [Required(ErrorMessage = "Balance is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a non-negative number")]
        public float Balance { get; set; }

        public List<long> Transactions { get; set; } = new List<long>();

        public List<long> Loans { get; set; } = new List<long>();
    }
}
