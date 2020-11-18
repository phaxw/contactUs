using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using contactUs.Models;
using Microsoft.AspNetCore.Mvc;

namespace contactUs.Interfaces
{
    public interface IContact
    {
        public Task<Contact> add([FromBody] Contact contact);

        public Task<Contact> get();

        public Task<List<Contact>> getAll();
    }
}