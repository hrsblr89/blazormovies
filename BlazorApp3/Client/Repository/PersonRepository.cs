﻿using BlazorApp3.Client.Helpers;
using BlazorApp3.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp3.Client.Repository
{
    public class PersonRepository: IPersonRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/people";
        public PersonRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<Person>> GetPeople()
        {
            var response = await _httpService.Get<List<Person>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task CreatePerson(Person person)
        {
            var response = await _httpService.Post(url, person);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

        }
    }
}