namespace Catalog.API.Handlers;

public class GetPlatesHandler(IPlatesRepository platesRepository, IPromotionService promotionService, IMarkUpService markUpService)
{
    public async Task<PagedList<PlateResponse>> Handle(GetPlatesQuery request)
    {
        var platesQuery = BuildPlatesQuery(request);
        decimal markUp = markUpService.GetCurrentMarkUp();
        decimal discount = promotionService.GetDiscountAmount(request.PromoCode);

        var platesResponseQuery = BuildPlatesResponseQuery(platesQuery, discount, markUp);

        var plates = await PagedList<PlateResponse>.CreateAsync(
            platesResponseQuery,
            request.Page,
            request.PageSize);

        return plates;
    }
 
    private static IQueryable<PlateResponse> BuildPlatesResponseQuery(IQueryable<Plate> platesQuery, decimal discount, decimal markUp)
    {
        return platesQuery
           .Select(p => new PlateResponse(
               p.Id,
               p.Registration!,
               p.PurchasePrice,
               (p.SalePrice - discount) * markUp,
               p.Availability.ToString())
           );
    }

    private IQueryable<Plate> BuildPlatesQuery(GetPlatesQuery request)
    {
        IQueryable<Plate> platesQuery = platesRepository.Get();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            platesQuery = platesQuery.Where(p =>
                p.Registration!.Contains(request.SearchTerm));
        }

        if (request.SortOrder?.ToLower() == "desc")
        {
            platesQuery = platesQuery.OrderByDescending(GetSortProperty(request));
        }
        else
        {
            platesQuery = platesQuery.OrderBy(GetSortProperty(request));
        }

        if (request.HideUnavailable)
        {
            platesQuery = platesQuery.Where(plate => plate.Availability == Availability.Available);
        }
      
        return platesQuery;
    }

    private static Expression<Func<Plate, object>> GetSortProperty(GetPlatesQuery request) =>
        request.SortColumn?.ToLower() switch
        {
            "registration" => plate => plate.Registration!,
            "purchaseprice" => plate => plate.PurchasePrice,
            "saleprice" => plate => plate.SalePrice,
            _ => product => product.Id
        };
}