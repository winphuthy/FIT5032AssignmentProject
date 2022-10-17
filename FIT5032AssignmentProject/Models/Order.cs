using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT5032AssignmentProject.Models
{
    public class Order
    {
        [Key] public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0: dd MM yyyy h:mm tt}")]
        public DateTime OrderTime { get; set; }

        [Required] [ForeignKey("Service")] public int ServiceId { get; set; }

        public Service Service { get; set; }

        [Required] [ForeignKey("Patient")] public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [MaxLength(300)] public string Comment { get; set; }
    }
}