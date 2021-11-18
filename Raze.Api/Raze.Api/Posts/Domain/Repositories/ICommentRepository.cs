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
        Task<IEnumerable<Comment>> FindByPostId(int postId);
        void Update(Comment comment);
        void Remove(Comment comment);
    }
}