using System;
using System.ComponentModel.DataAnnotations;

namespace FIT5032AssignmentProject.Models
{
    public class Admin
    {
        [Key] public int AdminID { get; set; }

        [Required] [MaxLength(30)] public string FirstName { get; set; }
        [Required] [MaxLength(30)] public string LastName { get; set; }

        public DateTime Dob { get; set; }
    }
}