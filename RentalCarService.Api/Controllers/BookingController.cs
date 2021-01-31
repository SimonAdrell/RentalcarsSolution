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
    public class BookingController : ControllerBase
    {
        // GET: api/<BookingController>
        RentalContext _rentalContext;
        RentalHandling _rentalHandling;
        public BookingController(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
            _rentalHandling = new RentalHandling(rentalContext);
        }

        [HttpGet]
        public ActionResult<List<Booking>> Get()
        {
            return Ok(_rentalContext.Booking);
        }

        // GET api/<BookingController>/5
        [HttpGet("{bookingNumber}")]
        public ActionResult<Booking> Get(string bookingNumber)
        {
            Booking booking = _rentalContext.Booking.Where(b => b.BookingNumber == bookingNumber).OrderBy(b => b.BookingID).LastOrDefault();
            if (booking is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(booking);
            }
        }

        // POST api/<BookingController>
        [HttpPost]
        public ActionResult  Post([FromBody] RentalRegistrationModel value)
        {
            if (ModelState.IsValid)
            {
                var Validator = new RentalRegistrationValidation();
                var validationResult = Validator.Validate(value);
                if (validationResult.IsValid)
                {
                    return Ok(_rentalHandling.Register(value));
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
