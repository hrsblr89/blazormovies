﻿using BlazorApp3.Client.Helpers;
using BlazorApp3.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp3.Client.Repository
{
    public class GenreRepository: IGenreRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/genres";
        public GenreRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<Genre>> GetGenres()
        {
            var response = await _httpService.Get<List<Genre>>(url);
            if(!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }


        public async Task<Genre> GetGenre(int id)
        {
            var response = await _httpService.Get<Genre>($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task CreateGenre(Genre genre)
        {
            var response = await _httpService.Post(url, genre);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }


        public async Task UpdateGenre(Genre genre)
        {
            var response = await _httpService.Put(url, genre);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
