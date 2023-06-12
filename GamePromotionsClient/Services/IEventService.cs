using GamePromotionsClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotionsClient.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventModel>> GetEvents();
    }
}
