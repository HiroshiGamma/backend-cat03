using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_cat03.src.Interface;
using backend_cat03.src.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using backend_cat03.src.dtos.Post;
using Microsoft.AspNetCore.Http;

namespace backend_cat03.src.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostController(IPostRepository postRepository, IHttpContextAccessor httpContextAccessor)
        {
            _postRepository = postRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("all")]
        [Authorize]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var posts = await _postRepository.GetAll();
            return Ok(posts);
        }


        [HttpPost("create")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<ActionResult<Post>> CreatePost([FromForm] CreatePostDto createPostDto)
        {
            var PostModel = new Post 
            {
                Title = createPostDto.Title,
                Date = DateTime.Now.ToString("dd-MM-yyyy HH:mm"), 
            };

            await _postRepository.CreatePost(PostModel, createPostDto.Image);

            return CreatedAtAction(nameof(GetAllPosts), new { id = PostModel.Id }, PostModel);
        }

    }
}