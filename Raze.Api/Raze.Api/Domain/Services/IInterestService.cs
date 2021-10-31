using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Services
{
    public interface IInterestService
    {
        Task<IEnumerable<Interest>> ListAsync();
    }
}