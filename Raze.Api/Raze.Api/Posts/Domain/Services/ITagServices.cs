using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services.Communication;

namespace Raze.Api.Domain.Services
{
    public interface ITagServices
    {
        Task<IEnumerable<Tag>> ListAsync();
        Task<TagsResponse> SaveAsync(Tag tag);
        Task<Tag> FindByIdAsync(int id);
        Task<TagsResponse> UpdateAsync(int id, Tag tag);
        Task<TagsResponse> DeleteAsync(int id);
    }
}