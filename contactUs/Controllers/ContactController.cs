using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using contactUs.Models;
using System.Threading.Tasks;
using contactUs.Repository;
using contactUs.Repository.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace contactUs.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ContactController : Controller
    {

        private readonly IContactRepository IContact;

        public ContactController(IContactRepository IContact)
        {
            this.IContact = IContact;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> add([FromBody]Contact contact)
        {

            if (!ModelState.IsValid) BadRequest();

            var result = await IContact.add(contact);
            if (result == null)
            {
                return StatusCode(500);
            }

            return Ok(new
            {
                message = "Agregado",
                data = contact
            });
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> get(int id)
        {
            var result = await IContact.get(id);
            if (result == null)
            {
                return StatusCode(500);
            }

            return Ok(new
            {
                message = "Agregado",
                data = result
            }); 
        }
    

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var results = await IContact.getAll();
            if (results == null)
            {
                return StatusCode(500);
            }

            return Ok(new
            {
                message = "obtenidos",
                data = results
            });
        }

    }
}
