using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techbuzzers_bank.Models
{
    public class Payables
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Loans))]
        public String loanId { get; set; }
        public int month {  get; set; }
        public float amount { get; set; }
        public string status { get; set; } = "Pending"; // Due/ Done / Pending
    }
}
