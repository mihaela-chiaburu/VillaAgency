using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class ReviewViewModel
    {
        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string Content { get; set; }
    }
}
