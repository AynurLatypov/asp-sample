namespace Trade.Data.Models
{
    public class Position
    {
        public int Id { get; set; }
        
        public string Symbol { get; set; }
        
        public bool IsLong { get; set; }
        
        public int PositionSize { get; set; }
        
        public int PortfolioId { get; set; }
    }
}