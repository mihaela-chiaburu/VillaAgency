﻿using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class Villa
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public double Area { get; set; }
        public int Parking { get; set; }

        public string ImageUrl { get; set; }
    }
}