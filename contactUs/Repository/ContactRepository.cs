﻿using System;
using Microsoft.Extensions.Configuration;
using contactUs.Models;
using contactUs.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Npgsql;
using Dapper;
using System.Threading.Tasks;

namespace contactUs.Repository
{
    public class ContactRepository : IContactRepository
    {

        private readonly string postgresConnection = "";
        List<Contact> listOfContacts = new List<Contact>();

        public ContactRepository(string postgresConnection)
        {
            this.postgresConnection = postgresConnection;
        }

        public async Task<Contact> add(Contact contact)
        {
            Contact queryResult = new Contact();
            string sSql = "INSERT INTO Contact (nombre, email, numero_telefonico, compañia, mensaje) VALUES(@nombre, @email, @numero_telefonico, @compañia, @mensaje)";

            using (var connection = new NpgsqlConnection(postgresConnection))
            {
                try
                {
                    queryResult = await connection.QuerySingleOrDefaultAsync<Contact>(sSql, new { nombre = contact.Nombre, email = contact.Email, numero_telefonico = contact.NumeroTelefonico, compañia = contact.Compañia, mensaje = contact.Mensaje });
                }
                catch (Exception e)
                {
                    queryResult = null;
                    return queryResult;
                }
            }
            return queryResult;
        }

        public Task<Contact> get()
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> getAll()
        {
            throw new NotImplementedException();
        }
    }
}
