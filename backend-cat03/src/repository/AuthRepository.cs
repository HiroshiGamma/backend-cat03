using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_cat03.src.Interface;
using backend_cat03.src.models;
using backend_cat03.src.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using backend_cat03.src.services;
using backend_cat03.src.dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace backend_cat03.src.repository
{

    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;

        private readonly ITokenService _tokenService;

        private readonly SignInManager<User> _signInManager;
        
        public AuthRepository(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }


        public async Task<NewUserDto> LoginAsync(LoginRegisterDto LoginRegisterDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == LoginRegisterDto.Email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }   

            var result = await _signInManager.CheckPasswordSignInAsync(user, LoginRegisterDto.Password, false);

            if(!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            return new NewUserDto  
            {
                Email = user.Email!,
                Token = await _tokenService.CreateToken(user)
            };
        }

        public async Task<NewUserDto> RegisterAsync(LoginRegisterDto LoginRegisterDto)
        {
            if (string.IsNullOrEmpty(LoginRegisterDto.Password))
            {
                throw new ArgumentException("Password is required");
            }

            var existingUser = await _userManager.FindByEmailAsync(LoginRegisterDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Email is already in use");
            }

            var user = new User
            {
                Email = LoginRegisterDto.Email,
                UserName = LoginRegisterDto.Email 
            };

            var createUser = await _userManager.CreateAsync(user, LoginRegisterDto.Password);

            if (!createUser.Succeeded)
            {
                throw new InvalidOperationException(string.Join(";", createUser.Errors.Select(x => x.Description)));
            }   

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if(!roleResult.Succeeded)
            {
                throw new InvalidOperationException(string.Join(";", roleResult.Errors.Select(x => x.Description)));
            }   

            var roles = await _userManager.GetRolesAsync(user);

            return new NewUserDto
            {
                Email = user.Email,
                Role = roles.First(),
                Token = await _tokenService.CreateToken(user)
            };
        }


    
    }
}