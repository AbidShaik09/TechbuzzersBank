using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techbuzzers_bank.Models
{
    public class Account
    {
        [Key]
        public int accountId { get; set; }
        public string accountHolderName { get; set; }
        public Account(String accountHolderName)
        {
            this.accountHolderName= accountHolderName;

        }
        [ForeignKey("UsserDetails")]
        public virtual UserDetails UserDetails { get; set; }    
    }
}
