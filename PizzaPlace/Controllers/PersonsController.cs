using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.Models;

namespace PizzaPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PizzaContext _context;
        public PersonsController(PizzaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            return Ok(_context.Person.ToList());
        }

        [HttpGet("{namePerson}")]
        public IActionResult GetPizza(string namePerson)
        {
            var person = _context.Person.FirstOrDefault(e => e.Name == namePerson);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create(Person newPerson)
        {
            _context.Person.Add(newPerson);
            _context.SaveChanges();
            return StatusCode(201, newPerson);

        }

        [HttpPut]
        public IActionResult Update(Person updatedPerson)
        {
            if (_context.Person.Count(e => e.Name == updatedPerson.Name) == 0)
            {
                return NotFound();
            }

            _context.Person.Attach(updatedPerson);
            _context.Entry(updatedPerson).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPerson);
        }

        [HttpDelete("{namePerson}")]
        public IActionResult Delete(string namePerson)
        {
            var person = _context.Person.FirstOrDefault(e => e.Name == namePerson);
            if (person == null)
            {
                return NotFound();
            }
            _context.Person.Remove(person);
            _context.SaveChanges();
            return Ok(person);
        }
    }
}