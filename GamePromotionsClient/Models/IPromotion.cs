using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GamePromotionsClient.Models
{
    public interface IPromotion
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime StartsAt { get; set; }
        DateTime ExpiresAt { get; set; }
        void Accept(IPromotionVisitor visitor);
    }
}
