using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_cat03.src.models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        
    }
}