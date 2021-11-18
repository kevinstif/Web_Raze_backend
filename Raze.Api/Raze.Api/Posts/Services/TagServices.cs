using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Domain.Services;
using Raze.Api.Domain.Services.Communication;
using Raze.Api.Shared.Domain.Repositories;

namespace Raze.Api.Services
{
    public class TagServices:ITagServices
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagServices(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await _tagRepository.ListAsync();
        }

        public async Task<TagsResponse> SaveAsync(Tag tag)
        {

            var existingTag = _tagRepository.FindByTitleAsync(tag.Title);

            if (existingTag.Result.Any())
                return new TagsResponse("This tag already exist");

            try
            {
                await _tagRepository.AddAsync(tag);
                await _unitOfWork.CompleteAsync();
                return new TagsResponse(tag);

            }
            catch (Exception e)
            {
                return new TagsResponse($"An error occurred while saving the tag:{e.Message}");
            }
        }

        public async Task<Tag> FindByIdAsync(int id)
        {
            return await _tagRepository.FindByIdAsync(id);
        }

        public async Task<TagsResponse> UpdateAsync(int id, Tag tag)
        {
            var existingTag = await _tagRepository.FindByIdAsync(id);
            if (existingTag==null)
                return new TagsResponse("Tag not found");

            existingTag.Title = tag.Title;
            
            try
            {
                _tagRepository.Update(existingTag);
                await _unitOfWork.CompleteAsync();
                return new TagsResponse(existingTag);
            }
            catch (Exception e)
            {
                return new TagsResponse($"An error occurred while updating the Comment:{e.Message}");
            }
        }

        public async Task<TagsResponse> DeleteAsync(int id)
        {
            var existingTag = await _tagRepository.FindByIdAsync(id);
            if (existingTag==null)
                return new TagsResponse("Tag not found");

            try
            {
                _tagRepository.Remove(existingTag);
                await _unitOfWork.CompleteAsync();
                return new TagsResponse(existingTag);
            }
            catch (Exception e)
            {
                return new TagsResponse($"An error occurred while deleting the Comment:{e.Message}");
            }
        }
    }
}