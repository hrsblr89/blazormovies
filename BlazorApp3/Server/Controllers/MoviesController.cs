using BlazorApp3.Server.Helpers;
using BlazorApp3.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileStorageService _fileStorageService;
        public MoviesController(ApplicationDbContext context, IFileStorageService fileStorageService)
        {
            _context = context;
            _fileStorageService = fileStorageService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Movie movie)
        {
            if (!string.IsNullOrEmpty(movie.Poster))
            {
                var personPicture = Convert.FromBase64String(movie.Poster);
                movie.Poster = await _fileStorageService.SaveFile(personPicture, "jpg", "movies");
            }

            _context.Add(movie);
            await _context.SaveChangesAsync();
            return movie.Id;
        }
    }
}
