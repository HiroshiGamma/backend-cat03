using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_cat03.src.data;
using backend_cat03.src.Interface;
using backend_cat03.src.models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace backend_cat03.src.repository
{
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext _context;

        private readonly Cloudinary _cloudinary; 

        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostRepository(ApplicationDbContext context, Cloudinary cloudinary, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _cloudinary = cloudinary;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> CreatePost(Post post, IFormFile? image)
        {

            
            if (await FindPost(post.Title))
            {
                throw new Exception("A product with the same name and type already exists.");
            }
            
            if (image == null || image.Length == 0)
            {
                throw new Exception("Image is required");
            }
            
            if (image.ContentType != "image/jpeg" && image.ContentType != "image/png" &&
                !image.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) &&
                !image.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Image must be a JPEG or PNG file");
                }
            
            if (image.Length > 5 * 1024 * 1024) 
            {
                throw new Exception("Image must be less than 5MB");
            }

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(image.FileName, image.OpenReadStream()),
                Folder = "cat03",
                 
            };
            
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
         
            if (uploadResult.Error != null)
            {
                throw new Exception(uploadResult.Error.Message);
            }

            
            post.ImageUrl = uploadResult.SecureUrl.ToString();
            post.Date = DateTime.Now.ToString("dd-MM-yyyy HH:mm");

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null || httpContext.User == null)
            {
                throw new Exception("User context is not available");
            }

            var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new Exception("User identifier claim is not available");
            }

            var userId = userIdClaim.Value;
            post.UserId = userId;

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return post; 
        }

        private async Task<bool> FindPost(string title)
        {
            return await _context.Posts.AnyAsync(p => p.Title == title); 
        }

        public Task CreatePost(object post)
        {
            throw new NotImplementedException();
        }
    }
}