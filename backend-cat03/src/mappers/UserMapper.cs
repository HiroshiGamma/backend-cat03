using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_cat03.src.dtos;
using backend_cat03.src.models;

namespace backend_cat03.src.mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Email = user.Email!,
                Password = user.Password
            };
        }
    }
}