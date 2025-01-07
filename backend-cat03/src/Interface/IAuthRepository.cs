using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_cat03.src.dtos;
using backend_cat03.src.models;

namespace backend_cat03.src.Interface
{
    public interface IAuthRepository
    {
        Task<NewUserDto> RegisterAsync(UserDto userDto);
        Task<NewUserDto> LoginAsync(UserDto userDto);
    }
}