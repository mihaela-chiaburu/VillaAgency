using eUseControl.Domain.Entities.Villa;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entities
{
    public class VisitRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required]
        public DateTime VisitTime { get; set; }

        public string Notes { get; set; }

        [ForeignKey("PropertyId")]
        public virtual VillaDbTable Property { get; set; }
    }
}
