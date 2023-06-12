using GamePromotionsClient.Enums;

namespace GamePromotionsClient.Models
{
    public class OfferModel : ModelBase, IPromotion
    {
        public OfferTypes OfferType { get; set; }

        public void Accept(IPromotionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
