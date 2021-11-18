﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Shared.Persistence.Contexts;
using Raze.Api.Shared.Persistence.Repositories;

namespace Raze.Api.Persistence.Repositories
{
    public class CommentRepository: BaseRepository,ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> ListAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public async Task<Comment> FindByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> FindByPostId(int postId)
        {
            return await _context.Comments
                .Where(p => p.PostId == postId)
                .Include(p => p.Post)
                .ToListAsync();
        }

        public void Update(Comment comment)
        { 
            _context.Comments.Update(comment);
        }

        public void Remove(Comment comment)
        {
            _context.Comments.Remove(comment);
        }
    }
}