using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032AssignmentProject.Models
{
    public class Patient
    {
        [Key] public int PatientID { get; set; }

        [Required] [MaxLength(30)] public string FirstName { get; set; }
        [Required] [MaxLength(30)] public string LastName { get; set; }

        public DateTime Dob { get; set; }
    }
}