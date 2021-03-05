using System.Collections.Generic;
using System.Threading.Tasks;
using Trade.Models;

namespace Trade.Services
{
    public interface IPortfolioService
    {
        /// <summary>
        /// Get stocks portfolios without positions inside
        /// </summary>
        Task<IEnumerable<PortfolioModel>> GetAll();
        
        /// <summary>
        /// Get stock portfolio with all positions
        /// </summary>
        Task<PortfolioModel> GetById(int id);
        
        Task<PortfolioModel> Create(PortfolioModel model);
        
        Task<PortfolioModel> Update(PortfolioModel model);
        
        Task Delete(int id);
    }
}