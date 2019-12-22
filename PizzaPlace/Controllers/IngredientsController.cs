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
    public class IngredientsController : ControllerBase
    {
        private readonly PizzaContext _context;
        public IngredientsController(PizzaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetIngredients()
        {
            return Ok(_context.Ingredient.ToList());
        }

        [HttpGet("{nameIngredient}")]
        public IActionResult GetIngredient(string nameIngredient)
        {
            var ingredient = _context.Ingredient.FirstOrDefault(e => e.IngredientName == nameIngredient);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        [HttpPost]
        public IActionResult Create(Ingredient newIngredient)
        {
            _context.Ingredient.Add(newIngredient);
            _context.SaveChanges();
            return StatusCode(201, newIngredient);

        }

        [HttpPut]
        public IActionResult Update(Ingredient updatedIngredient)
        {
            if (_context.Ingredient.Count(e => e.IngredientName == updatedIngredient.IngredientName) == 0)
            {
                return NotFound();
            }

            _context.Ingredient.Attach(updatedIngredient);
            _context.Entry(updatedIngredient).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedIngredient);
        }

        [HttpDelete("{nameIngredient}")]
        public IActionResult Delete(string nameIngredient)
        {
            var ingredient = _context.Ingredient.FirstOrDefault(e => e.IngredientName == nameIngredient);
            if (ingredient == null)
            {
                return NotFound();
            }
            _context.Ingredient.Remove(ingredient);
            _context.SaveChanges();
            return Ok(ingredient);
        }
    }
}