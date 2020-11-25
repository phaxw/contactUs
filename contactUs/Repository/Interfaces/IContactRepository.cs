using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using contactUs.Models;
using Microsoft.AspNetCore.Mvc;

namespace contactUs.Repository.Interfaces
{
    public interface IContactRepository
    {
        public Task<Contact> add([FromBody] Contact contact);

        public Task<Contact> get(int id);

        public Task<IEnumerable<Contact>> getAll();
    }
}