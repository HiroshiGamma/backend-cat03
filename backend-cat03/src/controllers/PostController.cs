using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_cat03.src.Interface;
using backend_cat03.src.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace backend_cat03.src.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var posts = await _postRepository.GetAll();
            return Ok(posts);
        }
    }
}