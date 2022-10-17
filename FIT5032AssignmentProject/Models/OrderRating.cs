using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT5032AssignmentProject.Models
{
    public class OrderRating
    {
        [Key] public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0: dd MM yyyy h:mm tt}")]
        public DateTime RatingTime { get; set; }

        [MaxLength(300)] public string Content { get; set; }

        [Required] [ForeignKey("Order")] public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}