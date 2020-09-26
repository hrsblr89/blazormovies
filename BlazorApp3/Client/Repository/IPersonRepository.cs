﻿using BlazorApp3.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp3.Client.Repository
{
    public interface IPersonRepository
    {
        Task CreatePerson(Person person);
        Task<List<Person>> GetPeople();
        Task<List<Person>> GetPeopleByName(string name);
        Task<Person> GetPerson(int id);
        Task UpdatePerson(Person person);
    }
}
