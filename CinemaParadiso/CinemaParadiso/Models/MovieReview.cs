using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaParadiso.Models
{
    public class MovieReview
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int MovieId { get; set; }
    }
}