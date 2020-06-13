using RentAShow.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace RentAShow.ViewModels
{
    public class MovieFormViewModel
    {
        public int? ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }


        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                return ID != null ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            ID = 0; //We set this field in default constructor so that for new record, the hidden field will get populated.
        }

        public MovieFormViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}