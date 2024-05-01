using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text.Json.Serialization;
using System.Transactions;

namespace Techbuzzers_bank.Models
{
    public class UserDetails
    {
        [Key]
        public String id { get; set; }
        [Required]
        public String firstName { get; set; }
        [Required]
        public String lastName { get; set; }
        [Required]
        public long phoneNumber {  get; set; }
        [Required]
        public string email { get; set; }



        [Required]
        public int age { get; set; } //calculate from DOB
        [Required]
        public DateTime dob {  get; set; }
        [Required]
        public String address {  get; set; }
        

        [ForeignKey(nameof(Account))]
        public String accountId { get; set; }
        [Required]
        public int pin { get; set; }


    }
}
