using System.Collections.Generic;

namespace Trade.Models
{
    public class PortfolioModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int OwnerId { get; set; }
        
        public IEnumerable<StockPosition> Positions { get; set; }
    }
}