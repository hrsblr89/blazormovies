using BlazorApp3.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp3.Shared.DTO
{
    public class IndexPageDTO
    {
        public List<Movie> InTheaters { get; set; }
        public List<Movie> UpComingReleases { get; set; }
    }
}
