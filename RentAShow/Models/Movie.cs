using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentAShow.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string  Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

    }
}