﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp3.Shared.Entities
{
    public class MoviesGenres
    {
        public int MovieId { get; set; }
        public int GenreID { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
