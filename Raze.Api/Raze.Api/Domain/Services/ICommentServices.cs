using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Services
{
    public interface ICommentServices
    {
        Task<IEnumerable<Comment>> ListAsync();
        Task<Comment> SaveAsync(Comment comment);
        Task<Comment> FindByIdAsync(int id);
        Task<Comment> UpdateAsync(int id, Comment comment);
        Task<Comment> DeleteAsync(int id);
    }
}