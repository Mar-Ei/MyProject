using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using мед.журнал.Contracts.User;


namespace мед.журнал.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

 

    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = new User()
            {

                Surname = request.Surname,
                DateOfBirth = request.DateOfBirth,
                Name = request.Name,
                Email = request.Email,
                PasswordHash = request.PasswordHash,
            };
            await _userService.Create(userDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            await _userService.Create(user);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.Update(user);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}