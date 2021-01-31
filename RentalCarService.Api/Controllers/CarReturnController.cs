using Microsoft.AspNetCore.Mvc;
using RentalCarService.Api.Models;
using RentalCarService.Api.Validators;
using RentalCarsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentalCarService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReturnController : ControllerBase
    {
        RentalHandling _rentalHandling;
        RentalContext _rentalContext;
        public CarReturnController( RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
            _rentalHandling = new RentalHandling(rentalContext);
        }
        // POST api/<CarReturnController>
        [HttpPost]
        public ActionResult Post([FromBody] RentalReturnModel value)
        {
            if (ModelState.IsValid)
            {
                var Validator = new RentalReturnModelValidator(_rentalContext);
                var validationResult = Validator.Validate(value);
                if (validationResult.IsValid)
                {
                 return Ok(_rentalHandling.ReturnBooking(value.BookingNumber, value.CurrentMilage, 300,2));
                }
                else
                {
                    return BadRequest(validationResult.ToString(","));
                }
            }
            return BadRequest();
        }
    }
}
