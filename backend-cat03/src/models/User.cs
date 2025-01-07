using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace backend_cat03.src.models
{
    public class User : IdentityUser
    {
        public string Password { get; set; } = string.Empty;

        public List<Post> Posts { get; set; } = new List<Post>(); 
    }
}