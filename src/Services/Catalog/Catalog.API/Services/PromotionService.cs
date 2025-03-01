namespace Catalog.API.Services;

public class PromotionService : IPromotionService
{
    public decimal GetDiscountAmount(string? promotionCode)
    {
        return promotionCode switch
        {
            "DISCOUNT" => 25,
            _ => 0,
        };
    }
}

public interface IPromotionService
{
    public decimal GetDiscountAmount(string? promotionCode);
}