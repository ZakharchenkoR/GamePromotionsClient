using GamePromotionsClient.Enums;

namespace GamePromotionsClient.Models
{
    public class EventModel : ModelBase, IPromotion
    {
        public EventTypes EventType { get; set; }

        public void Accept(IPromotionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
