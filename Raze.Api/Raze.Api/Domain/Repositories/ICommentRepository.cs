using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> ListAsync();
        Task AddAsync(Comment comment);
        Task<Comment> FindByIdAsync(int id);
        void Update(Comment comment);
        void Remove(Comment comment);
    }
}