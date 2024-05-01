using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Transactions;

namespace Techbuzzers_bank.Models
{
    public class UserDetails
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String firstName { get; set; }
        [Required]
        public String lastName { get; set; }
        [Required]
        public long phoneNumber {  get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public DateTime dob {  get; set; }
        [Required]
        public String address {  get; set; }
        
        public Account account {  get; set; } 
        
        List<Transactions> transactions { get; set; } = new List<Transactions>();
    }
}
