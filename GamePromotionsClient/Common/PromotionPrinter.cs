using GamePromotionsClient.Models;
using System;

namespace GamePromotionsClient.Common
{
    public class PromotionPrinter : IPromotionVisitor
    {
        public void Visit(OfferModel offer)
        {
            PrintCommonDetails(offer);
            Console.WriteLine($"Promotion type: {offer.OfferType}");
            Console.WriteLine("--------------------------------------");
        }

        public void Visit(EventModel evnt)
        {
            PrintCommonDetails(evnt);
            Console.WriteLine($"Promotion type: {evnt.EventType}");
            Console.WriteLine("--------------------------------------");
        }

        private void PrintCommonDetails(IPromotion promotion)
        {
            Console.WriteLine($"Promotion Id: {promotion.Id}");
            Console.WriteLine($"Promotion Name: {promotion.Name}");
            Console.WriteLine($"Starts promotion: {promotion.StartsAt}");
            Console.WriteLine($"Expires promotion: {promotion.ExpiresAt}");
        }
    }
}
