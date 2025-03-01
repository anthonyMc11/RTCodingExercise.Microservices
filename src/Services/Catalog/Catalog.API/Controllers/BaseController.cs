namespace Catalog.API.Controllers;

public class BaseController : Controller
{
    protected const int DefaultPageNumber = 1;
    protected const int DefaultPageSize = 10;

    protected static void ValidatePageSize(ref int pageSize)
    {
        if (pageSize <= 0)
        {
            pageSize = DefaultPageSize;
        }
    }

    protected static void ValidatePage(ref int page)
    {
        if (page <= 0)
        {
            page = DefaultPageNumber;
        }
    }
}
