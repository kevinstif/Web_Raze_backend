using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Domain.Services;
using Raze.Api.Domain.Services.Communication;
using Raze.Api.Users.Domain.Repositories;

namespace Raze.Api.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IInterestRepository _interestRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, IInterestRepository interestRepository, ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _interestRepository = interestRepository;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _postRepository.ListAsync();
        }

        public async Task<IEnumerable<Post>> ListByUserAsync(int userId)
        {
            return await _postRepository.FindByAdvisorId(userId);
        }

        public async Task<IEnumerable<Post>> ListByTagAsync(int tagId)
        {
            return await _postRepository.FindByTagId(tagId);
        }

        public async Task<IEnumerable<Post>> ListByInterestAsync(int interestId)
        {
            return await _postRepository.FindByInterestId(interestId);
        }

        public async Task<Post> FindByIdAsync(int id)
        {
            var post = await _postRepository.FindByIdAsync(id);
            return post;
        }

        public async Task<PostResponse> SaveAsync(Post post)
        {
            var existingUser = await  _userRepository.FindbyIdAsync(post.UserId);
            if (existingUser == null)
            {
                return new PostResponse("User not found.");
            }

            var existingInterest = await _interestRepository.FindByIdAsync(post.InterestId);
            if (existingInterest == null)
            {
                return new PostResponse("Interest not found.");
            }

            var existingTag = await _tagRepository.FindByIdAsync(post.TagId);
            if (existingTag == null)
            {
                return new PostResponse("Tag not found.");
            }
            
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
            existingPost.UserId = post.UserId;
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