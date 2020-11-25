using System;
using Microsoft.Extensions.Configuration;
using contactUs.Models;
using contactUs.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Npgsql;
using Dapper;
using System.Linq;
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
            string sSql = "INSERT INTO contacts (nombre, email, numerotelefonico, compañia, mensaje) VALUES(@nombre, @email, @numerotelefonico, @compañia, @mensaje)";
            string sSql2 = "SELECT id, nombre, email, numerotelefonico, compañia, mensaje FROM contacts WHERE numerotelefonico = @numerotelefonico OR email = @email";
            Contact newContact = new Contact();
            using (var connection = new NpgsqlConnection(postgresConnection))
            {
                try
                {
                    await connection.QuerySingleOrDefaultAsync<Contact>(sSql, new { nombre = contact.Nombre, email = contact.Email, numerotelefonico = contact.NumeroTelefonico, compañia = contact.Compañia, mensaje = contact.Mensaje });
                    newContact = await connection.QuerySingleOrDefaultAsync<Contact>(sSql2, new { numerotelefonico = contact.NumeroTelefonico, email = contact.Email});
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return newContact;
        }

        public async Task<Contact> get(int id)
        {

            Contact contact = new Contact();
            string sSql = "SELECT id, nombre, email, numerotelefonico, compañia, mensaje FROM contacts WHERE id = @id";
            using (var connection = new NpgsqlConnection(postgresConnection))
            {
                try
                {
                    contact = await connection.QuerySingleOrDefaultAsync<Contact>(sSql, new { id = id});
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return contact;
        }

        public async Task<IEnumerable<Contact>> getAll()
        {
            IEnumerable<Contact> contacts;
            string sSql = "SELECT id, nombre, email, numerotelefonico, compañia, mensaje FROM contacts";
            using (var connection = new NpgsqlConnection(postgresConnection))
            {
                try
                {
                    contacts = await connection.QueryAsync<Contact>(sSql);
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return contacts;
        }
    }
}
