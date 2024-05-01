using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techbuzzers_bank.Models
{
    public class Account
    {
        [Key]
        public string id { get; set; }

        [ForeignKey("UsserDetails")]
        public String userId { get; set; }
        public float balance {  get; set; }
        List<Transactions> transactions { get; set; } = new List<Transactions>();
        List<Loans> loans { get; set; } = new List<Loans>();
    }
}
