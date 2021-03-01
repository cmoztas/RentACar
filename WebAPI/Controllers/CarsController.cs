using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _carService.GetAllDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbybrandid")]
        public IActionResult GetAllByBrandId(int brandId)
        {
            var result = _carService.GetAllByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbycolorid")]
        public IActionResult GetAllByColorId(int colorId)
        {
            var result = _carService.GetAllByColorId(colorId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbymodelyear")]
        public IActionResult GetAllByModelYear(int modelYear)
        {
            var result = _carService.GetAllByModelYear(modelYear);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbymodelyeargreaterthan")]
        public IActionResult GetAllByModelYearGreaterThan(int modelYear)
        {
            var result = _carService.GetAllByModelYearGreaterThan(modelYear);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbymodelyearlessthan")]
        public IActionResult GetAllByModelYearLessThan(int modelYear)
        {
            var result = _carService.GetAllByModelYearLessThan(modelYear);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbydailypricegreaterthan")]
        public IActionResult GetAllByDailyPriceGreaterThan(decimal price)
        {
            var result = _carService.GetAllByDailyPriceGreaterThan(price);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbydailypricelessthan")]
        public IActionResult GetAllByDailyPriceLessThan(decimal price)
        {
            var result = _carService.GetAllByDailyPriceLessThan(price);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _carService.Delete(_carService.GetById(id).Data);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}