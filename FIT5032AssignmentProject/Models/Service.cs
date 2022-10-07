using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT5032AssignmentProject.Models
{
    public class Service
    {
        [Key] public int Id { get; set; }

        [Required] [Display(Name = "Service Name")] public string Name { get; set; }

        [Required]
        [ForeignKey("Therapist")]
        public int TherapistId { get; set; }

        public Therapist Therapist { get; set; }

        [MaxLength(300)] public string Description { get; set; }
    }
}