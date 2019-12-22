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
    public class PizzasController : ControllerBase
    {
        private readonly PizzaContext _context;
        public PizzasController(PizzaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{namePizza}")]
        public IActionResult GetPizza(string namePizza)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.PizzaName == namePizza);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }

        [HttpPost]
        public IActionResult Create(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();
            return StatusCode(201, newPizza);

        }

        [HttpPut]
        public IActionResult Update(Pizza updatedPizza)
        {
            if (_context.Pizza.Count(e => e.PizzaName == updatedPizza.PizzaName) == 0)
            {
                return NotFound();
            }

            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);
        }

        [HttpDelete("{namePizza}")]
        public IActionResult Delete(string namePizza)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.PizzaName == namePizza);
            if (pizza == null)
            {
                return NotFound();
            }
            _context.Pizza.Remove(pizza);
            _context.SaveChanges();
            return Ok(pizza);
        }
    }
}