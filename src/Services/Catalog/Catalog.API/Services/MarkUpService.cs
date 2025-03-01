namespace Catalog.API.Services;

public class MarkUpService : IMarkUpService
{
    public decimal GetCurrentMarkUp()
    {
        return (decimal)1.2;
    }
}

public interface IMarkUpService
{
    public decimal GetCurrentMarkUp();
}