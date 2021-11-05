using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> ListAsync();
        Task<IEnumerable<Post>> FindByAdvicedId(int id);
        Task<IEnumerable<Post>> FindByAdvisorId(int id);
        Task AddAsync(Post post);
        Task<Post> FindByIdAsync(int id);
        void Update(Post post);
        void Remove(Post post);
    }
}