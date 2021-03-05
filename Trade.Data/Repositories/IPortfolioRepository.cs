using System.Collections.Generic;
using System.Threading.Tasks;
using Trade.Data.Models;

namespace Trade.Data.Repositories
{
    public interface IPortfolioRepository : IBaseRepository<Portfolio>
    {
        Task<IEnumerable<Portfolio>> GetOwnedPortfolios(int ownerId);
        Task DeleteMyPortfolio(int id, int ownerId);
    }
}