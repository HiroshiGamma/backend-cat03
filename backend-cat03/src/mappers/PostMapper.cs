using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_cat03.src.dtos.Post;
using backend_cat03.src.models;

namespace backend_cat03.src.mappers
{
    public static class PostMapper
    {
        public static Post toPostFromCreatePostDto(CreatePostDto createPostDto, string url)
        {
            return new Post
            {
                Title = createPostDto.Title,
                ImageUrl = url
            };
        } 
    }
}