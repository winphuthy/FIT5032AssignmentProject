using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT5032AssignmentProject.Models
{
    public class Order
    {
        [Key] public int Id { get; set; }

        [Required] public DateTime OrderTime { get; set; }

        [Required] [ForeignKey("Patient")] public int PatientId { get; set; }

    }
}