using System;

namespace GamePromotionsClient.Models
{
    public class ModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
