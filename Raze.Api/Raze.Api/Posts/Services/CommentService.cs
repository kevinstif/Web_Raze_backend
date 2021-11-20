using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Domain.Services;
using Raze.Api.Domain.Services.Comunications;
using Raze.Api.Shared.Domain.Repositories;

namespace Raze.Api.Services
{
    public class CommentService:ICommentServices
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Comment>> ListAsync()
        {
            return await _commentRepository.ListAsync();
        }

        public async Task<IEnumerable<Comment>> LisByPostAsync(int postId)
        {
            return await _commentRepository.FindByPostId(postId);
        }

        public async Task<CommentsResponse> SaveAsync(Comment comment)
        {
            
            try
            {
                await _commentRepository.AddAsync(comment);
                await _unitOfWork.CompleteAsync();
                return new CommentsResponse(comment);
            }
            catch (Exception e)
            {
                return new CommentsResponse($"An error occurred while saving the Comment:{e.Message}");
            }
        }

        public async Task<Comment> FindByIdAsync(int id)
        {
            var comment = await _commentRepository.FindByIdAsync(id);
            return comment;
        }

        public async Task<CommentsResponse> UpdateAsync(int id, Comment comment)
        {
            var commentExisting = await _commentRepository.FindByIdAsync(id);
            if (commentExisting==null)
                return new CommentsResponse("Comment not found");
            commentExisting.Text = comment.Text;
            try
            {
                _commentRepository.Update(commentExisting);
                await _unitOfWork.CompleteAsync();
                return new CommentsResponse(commentExisting);

            }
            catch (Exception e)
            {
                return new CommentsResponse($"An error occurred while updating Comment:{e.Message}");
            }
        }

        public async Task<CommentsResponse> DeleteAsync(int id)
        {
            var commentExisting = await _commentRepository.FindByIdAsync(id);
            if (commentExisting==null)
                return new CommentsResponse("Comment not found");

            try
            {
                _commentRepository.Remove(commentExisting);
                await _unitOfWork.CompleteAsync();
                return new CommentsResponse(commentExisting);

            }
            catch (Exception e)
            {
                return new CommentsResponse($"An error occurred while deleting Comment:{e.Message}");
            }
        }
    }
}