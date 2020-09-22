using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace BlazorApp3.Shared.Entities
{
    public class MoviesActors
    {
        public int PersonID { get; set; }
        public int MovieID { get; set; }
        public Person person { get; set; }
        public Movie Movie { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
    }
}
