using System;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Domain.Entities
{
    public class VisitRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime VisitTime { get; set; }

        public string Notes { get; set; }
    }
}
