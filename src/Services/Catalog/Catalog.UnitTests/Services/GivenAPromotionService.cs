namespace Catalog.UnitTests.Services;

public class GivenAPromotionService
{
    public PromotionService _sut;

    public GivenAPromotionService()
    {
        _sut = new();
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData("DISCOUNT", 25)]
    [InlineData("__", 0)]
    [InlineData("%Test", 0)]
    [InlineData("5off", 0)]
    [Trait("Type", "UnitTest")]
    public void WhenGivenAPromotionCode_ThenCorrectDiscountIsReturned(string? promotionCode, decimal expectedDiscountValue) 
    {
        var result = _sut.GetDiscountAmount(promotionCode);
        Assert.True(result == expectedDiscountValue);
    }
}