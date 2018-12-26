using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApiUdemy.Models;
using RestApiUdemy.Repositories;

namespace RestApiUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {

        private IPerson _personService;

        public PersonController(IPerson personService)
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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            if (person == null) return BadRequest();

            return new ObjectResult(_personService.Update(person));
        }

        [HttpDelete("{delete}")]
        public IActionResult Delete(int id)
        {

            _personService.Delete(id);

            return NoContent();
        }
    }
}