namespace Catalog.API.Models.Plates;

public record GetPlatesQuery(
    string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize,
    string? PromoCode,
    bool HideUnavailable);

public record PlateResponse(
    Guid Id,
    string Registration,
    decimal PurchasePrice,
    decimal SalePrice,
    string Availability);