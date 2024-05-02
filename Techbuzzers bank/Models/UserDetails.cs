﻿using Microsoft.AspNetCore.Identity;
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
        
        public long Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number")]
        public long PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Father name is required")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Adhaar number is required")]
        public long AdhaarNumber { get; set; }


        [Required(ErrorMessage = "PAN card number is required")]
        public long PANNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }



        
        public  List<long> accounts { get; set; }= new List<long> ();

        [Required(ErrorMessage = "PIN is required")]
        [Range(1000, 9999, ErrorMessage = "PIN must be a 4-digit number")]
        public int Pin { get; set; }
    }
}
