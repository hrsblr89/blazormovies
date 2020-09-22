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
    public class PeopleController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileStorageService _fileStorageService;
        public PeopleController(ApplicationDbContext context, IFileStorageService fileStorageService)
        {
            _context = context;
            _fileStorageService = fileStorageService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person)
        {
            if (!string.IsNullOrEmpty(person.Picture))
            {
                var personPicture = Convert.FromBase64String(person.Picture);
                person.Picture = await _fileStorageService.SaveFile(personPicture, "jpg", "people");
            }

            _context.Add(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }
    }
}
