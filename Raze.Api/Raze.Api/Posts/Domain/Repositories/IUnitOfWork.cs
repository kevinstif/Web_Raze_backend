using System.Threading.Tasks;

namespace Raze.Api.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}