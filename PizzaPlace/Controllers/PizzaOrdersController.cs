using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Models;

namespace PizzaPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaOrdersController : ControllerBase
    {
        private readonly PizzaContext _context;
        public PizzaOrdersController(PizzaContext context)
        {
            _context = context;
        }

    }
}