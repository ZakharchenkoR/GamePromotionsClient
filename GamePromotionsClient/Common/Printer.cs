using GamePromotionsClient.Models;

namespace GamePromotionsClient.Common
{
    public static class Printer
    {
        public static void Print(IPromotion promotion) 
        {
            IPromotionVisitor printer = new PromotionPrinter();
            promotion.Accept(printer);
        }
    }
}
