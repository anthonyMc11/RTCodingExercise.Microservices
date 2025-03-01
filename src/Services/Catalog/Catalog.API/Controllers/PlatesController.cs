using IntegrationEvents;
using MassTransit;

namespace Catalog.API.Controllers;

[Route("Plates")]
public class PlatesController(GetPlatesHandler getPlatesHandler, IBus bus) : BaseController
{
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> Get(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize, string? promoCode, bool hideUnavailable)
    {
        ValidatePage(ref page);
        ValidatePageSize(ref pageSize);

        var plates = await getPlatesHandler.Handle(new GetPlatesQuery(searchTerm, sortColumn, sortOrder, page, pageSize, promoCode, hideUnavailable));

        return new JsonResult(plates);
    }

    [HttpPost]
    [Route("{id}/reserve")]
    public async Task<IActionResult> Reserve(Guid id)
    {
        ReservePlateCommand reservationCommand = new(id);
        await bus.Publish(reservationCommand);

        //return an order summary for the user, for now just the event Id to simulate the successful reserve request response
        return new JsonResult(reservationCommand.Id);
    }
}