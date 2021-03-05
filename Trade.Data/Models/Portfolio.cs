using System;

namespace Trade.Data.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int OwnerId { get; set; }
    }
}