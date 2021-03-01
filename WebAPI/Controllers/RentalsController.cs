using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _rentalService.GetByCustomerId(customerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _rentalService.GetAllDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbycarid")]
        public IActionResult GetAllByCarId(int carId)
        {
            var result = _rentalService.GetAllByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbyrentdatenewthan")]
        public IActionResult GetAllByRentDateNewThan(DateTime rentDate)
        {
            var result = _rentalService.GetAllByRentDateNewThan(rentDate);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbyrentdateoldthan")]
        public IActionResult GetAllByRentDateOldThan(DateTime rentDate)
        {
            var result = _rentalService.GetAllByRentDateOldThan(rentDate);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbyreturndatenewthan")]
        public IActionResult GetAllByReturnDateNewThan(DateTime rentDate)
        {
            var result = _rentalService.GetAllByReturnDateNewThan(rentDate);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbyreturndateoldthan")]
        public IActionResult GetAllByReturnDateOldThan(DateTime rentDate)
        {
            var result = _rentalService.GetAllByReturnDateOldThan(rentDate);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _rentalService.Delete(_rentalService.GetById(id).Data);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}