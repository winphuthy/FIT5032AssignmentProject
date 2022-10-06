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

        public Patient Patient { get; set; }

        [Required] [ForeignKey("Therapist")] public int TherapistId { get; set; }

        public Therapist Therapist { get; set; }

        [Required] [ForeignKey("OrderRating")] public int RatingId { get; set; }

        public OrderRating OrderRating { get; set; }
    }
}