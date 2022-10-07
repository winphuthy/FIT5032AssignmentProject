using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT5032AssignmentProject.Models
{
    public class OrderRating
    {
        [Key] public int Id { get; set; }

        [Required] public DateTime RatingTime { get; set; }

        [MaxLength(300)] public string Content { get; set; }

        [Required] [ForeignKey("Order")] public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}