using System;
using System.ComponentModel.DataAnnotations;

namespace contactUs.Models
{
    public class Contact
    {
        public int id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Email { get; set; }

        public string NumeroTelefonico { get; set; }

        public string Compañia { get; set; }

        public string Mensaje { get; set; }
    }
}
