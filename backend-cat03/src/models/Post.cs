using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace backend_cat03.src.models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime Date { get; set; } 

        public string ImageUrl { get; set; } = string.Empty;

        public int UserId { get; set; }

        public User User { get; set; } = null!; 
    }
}