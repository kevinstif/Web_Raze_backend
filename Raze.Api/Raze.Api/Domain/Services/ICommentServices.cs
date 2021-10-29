using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services.Comunications;

namespace Raze.Api.Domain.Services
{
    public interface ICommentServices
    {
        Task<IEnumerable<Comment>> ListAsync();
        Task<CommentsResponse> SaveAsync(Comment comment);
        Task<CommentsResponse> FindByIdAsync(int id);
        Task<CommentsResponse> UpdateAsync(int id, Comment comment);
        Task<CommentsResponse> DeleteAsync(int id);
    }
}