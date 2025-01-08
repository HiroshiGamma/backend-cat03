using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_cat03.src.dtos.Post
{
    public class CreatePostDto
    {
        
        public string Title { get; set; } = string.Empty;

        public DateTime Date { get; set; } 

        public string ImageUrl { get; set; } = string.Empty;
    }
}