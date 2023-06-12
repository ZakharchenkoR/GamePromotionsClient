namespace GamePromotionsClient.Models
{
    public interface IPromotionVisitor
    {
        void Visit(OfferModel offer);
        void Visit(EventModel eventModel);
    }
}
