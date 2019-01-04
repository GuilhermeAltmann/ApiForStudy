using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApiUdemy.Models;
using RestApiUdemy.Repositories;
using RestApiUdemy.Repositories.Generic;

namespace RestApiUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {

        private IRepository<Person> _personService;

        public PersonController(IRepository<Person> personService)
        {

            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_personService.FindAll());
        } 

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var person = _personService.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
             if (person == null) return BadRequest();

            return new ObjectResult(_personService.Create(person));
        }

        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();

            var updatedPerson = _personService.Update(person);

            if(updatedPerson == null)
            {

                return NoContent();
            }

            return new ObjectResult(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _personService.Delete(id);

            return NoContent();
        }
    }
}