using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyemail")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByEmail(email);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbyfirstname")]
        public IActionResult GetAllByFirstName(string firstName)
        {
            var result = _userService.GetAllByFirstName(firstName);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbylastname")]
        public IActionResult GetAllByLastName(string lastName)
        {
            var result = _userService.GetAllByLastName(lastName);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbypassword")]
        public IActionResult GetAllByPassword(string password)
        {
            var result = _userService.GetAllByPassword(password);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(_userService.GetById(id).Data);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}