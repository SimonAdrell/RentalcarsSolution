using Microsoft.AspNetCore.Mvc;
using RentalCarService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentalCarService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly RentalContext _context;
        public CarsController(RentalContext context)
        {
            _context = context;
        }
        // GET: api/<CarsController>
        [HttpGet]
        public List<Car> Get()
        {
            return _context.Cars.ToList();

        }
        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            if (ModelState.IsValid)
            {
                _context.Cars.Add(value);
                _context.SaveChanges();
            }
        }
    }
}
