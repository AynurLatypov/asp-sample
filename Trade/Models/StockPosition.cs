namespace Trade.Models
{
    public class StockPosition
    {
        public int Id { get; set; }
        
        public string Symbol { get; set; }
        
        public PositionType PositionType { get; set; }
        
        public int PositionSize { get; set; }
    }
}