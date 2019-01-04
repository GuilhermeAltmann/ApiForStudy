using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiUdemy.Models;
using RestApiUdemy.Repositories;

namespace RestApiUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IBook _bookService;

        public BookController(IBook bookService)
        {

            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var person = _bookService.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();

            return new ObjectResult(_bookService.Create(book));
        }

        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();

            var updatedPerson = _bookService.Update(book);

            if (updatedPerson == null)
            {

                return NoContent();
            }

            return new ObjectResult(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _bookService.Delete(id);

            return NoContent();
        }
    }
}