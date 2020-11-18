﻿using System;
using Microsoft.Extensions.Configuration;
using contactUs.Interfaces;
using contactUs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Npgsql;
using Dapper;
using System.Threading.Tasks;

namespace contactUs.Repository
{
    public class ContactRepository : IContact
    {

        private IConfiguration _configuration;
        private string connectionString = "";
        List<Contact> listOfContacts = new List<Contact>();

        public ContactRepository()
        {
            connectionString = _configuration.GetConnectionString("HerokuBDPostgresql");
        }

        public async Task<Contact> add(Contact contact)
        {
            Contact queryResult = new Contact();
            string sSql = "INSERT INTO Contact (nombre, email, numero_telefonico, compañia, mensaje) VALUES(@nombre, @email, @numero_telefonico, @compañia, @mensaje)";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    queryResult = await connection.QuerySingleOrDefaultAsync<Contact>(sSql, new { nombre = contact.nombre, email = contact.email, numero_telefonico = contact.numero_telefonico, compañia = contact.compañia, mensaje = contact.mensaje });
                }
                catch (Exception e)
                {
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