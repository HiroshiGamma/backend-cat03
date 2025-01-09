using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend_cat03.src.dtos.Post
{
    public class CreatePostDto
    {
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters long.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        public IFormFile? Image { get; set; } = null!;
    }
}