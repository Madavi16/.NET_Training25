using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CodeFirst.Models
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public string DirectorName { get; set; }

        [Required]
        public DateTime DateOfRelease { get; set; }
    }
}