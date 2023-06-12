using GamePromotionsClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotionsClient.Services
{
    public interface IOfferService
    {
        Task<IEnumerable<OfferModel>> GetOffers();
    }
}
