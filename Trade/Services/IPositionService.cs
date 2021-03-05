using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trade.Models;

namespace Trade.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<StockPosition>> GetPositions(int portfolioId);
        
        Task<IEnumerable<StockPosition>> CreatePositions(int portfolioId, IEnumerable<StockPosition> position);
        Task<StockPosition> CreatePosition(int portfolioId, StockPosition position);
        
        Task<StockPosition> UpdatePosition(StockPosition position);
        Task<IEnumerable<StockPosition>> UpdatePositions(IEnumerable<StockPosition> position);

        Task DeletePosition(int id);
        Task DeletePositions(IEnumerable<int> id);
    }
}