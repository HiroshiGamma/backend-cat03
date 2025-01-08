using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_cat03.src.data;
using backend_cat03.src.Interface;
using backend_cat03.src.models;
using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;

namespace backend_cat03.src.repository
{
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext _context;

        private readonly Cloudinary _cloudinary; 

        public PostRepository(ApplicationDbContext context, Cloudinary cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        


    }
}