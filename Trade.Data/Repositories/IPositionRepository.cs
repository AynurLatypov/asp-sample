using System.Collections.Generic;
using System.Threading.Tasks;
using Trade.Data.Models;

namespace Trade.Data.Repositories
{
    public interface IPositionRepository : IBaseRepository<Position>
    {
        Task<IEnumerable<Position>> GetPortfolioPositions(int position);
        Task<IEnumerable<(int portfolioId, IEnumerable<Position> positions)>> GetPortfoliosPositions(IEnumerable<int> portfolios);
    }
}