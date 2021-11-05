using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services.Communication;

namespace Raze.Api.Domain.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> ListAsync();
        Task<Post> FindByIdAsync(int id);
        Task<PostResponse> SaveAsync(Post post);
        Task<PostResponse> UpdateAsync(int id, Post post);
        Task<PostResponse> DeleteAsync(int id);
    }
}