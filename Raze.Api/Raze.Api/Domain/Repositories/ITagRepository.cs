using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> ListAsync();
        Task AddAsync(Tag comment);
        Task<Tag> FindByIdAsync(int id);
        void Update(Tag tag);
        void Remove(Tag tag);
    }
}