using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_cat03.src.dtos;
using backend_cat03.src.Interface;
using Microsoft.AspNetCore.Mvc;
 


namespace backend_cat03.src.controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {

            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newUser = await _authRepository.RegisterAsync(userDto);
                return Ok(newUser);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto  userDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newUser = await _authRepository.LoginAsync(userDto);
                return Ok(newUser);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

       

    }
}