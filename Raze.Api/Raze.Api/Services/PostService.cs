using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Domain.Services;
using Raze.Api.Domain.Services.Communication;

namespace Raze.Api.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _postRepository.ListAsync();
        }

        public async Task<PostResponse> SaveAsync(Post post)
        {
            try
            {
                await _postRepository.AddAsync(post);
                await _unitOfWork.CompleteAsync();

                return new PostResponse(post);
            }
            catch (Exception e)
            {
                return new PostResponse($"An error occurred while saving the post: {e.Message}");
            }
        }

        public async Task<PostResponse> UpdateAsync(int id, Post post)
        {
            var existingPost = await _postRepository.FindByIdAsync(id);
            if (existingPost == null)
            {
                return new PostResponse("Post not found");
            }

            existingPost.Title = post.Title;
            existingPost.Image = post.Image;
            existingPost.Description = post.Description;
            existingPost.Rate = post.Rate;
            existingPost.NumberOfRates = post.NumberOfRates;
            existingPost.InterestId = post.InterestId;

            try
            {
                _postRepository.Update(existingPost);
                await _unitOfWork.CompleteAsync();
                return new PostResponse(existingPost);
            }
            catch (Exception e)
            {
                return new PostResponse($"An error occurred while updating the post: {e.Message}");
            }
        }

        public async Task<PostResponse> DeleteAsync(int id)
        {
            var existingPost = await _postRepository.FindByIdAsync(id);
            if (existingPost == null)
            {
                return new PostResponse("Post not found");
            }

            try
            {
                _postRepository.Remove(existingPost);
                await _unitOfWork.CompleteAsync();
                return new PostResponse(existingPost);
            }
            catch (Exception e)
            {
                return new PostResponse($"An error occurred while deleting the post: {e.Message}");
            }
        }
    }
}