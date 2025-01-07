using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend_cat03.src.dtos
{
    public class NewUserDto
    {

        [Required]
        [EmailAddress]
        public string Email {get; set; } = null!;

        [Required]
        public string Token {get; set; } = null!;
    }
}