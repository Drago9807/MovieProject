using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Producer { get; set; }

        [Column("Date")]
        [Display(Name = "Date of premiere")]
        public string PremierDate { get; set; }

        [Column("Price")]
        [Display(Name = "Price")]
        public decimal MoviePrice { get; set; }
    }
}