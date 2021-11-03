using System.Threading.Tasks;

namespace Raze.Api.Users.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}