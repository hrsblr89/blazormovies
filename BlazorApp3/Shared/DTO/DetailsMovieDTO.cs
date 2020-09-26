using BlazorApp3.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp3.Shared.DTO
{
    public class DetailsMovieDTO
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Person> Actors { get; set; }
    }
}
