using BlazorApp3.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp3.Client.Helpers
{
    public interface IRepository
    {
        List<Movie> GetMovies();
    }
}
