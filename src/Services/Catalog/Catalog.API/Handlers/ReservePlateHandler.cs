using IntegrationEvents;
using MassTransit;

namespace Catalog.API.Handlers;

public class ReservePlateHandler(IPlatesRepository platesRepository, IBus bus) : IConsumer<ReservePlateCommand>
{

    public async Task Consume(ConsumeContext<ReservePlateCommand> context)
    {
        var successful = await platesRepository.Reserve(context.Message.PlateId);

        if (successful)
        {
            await bus.Publish(context.Message.ToSucceeded());
        }
        else
        {
            await bus.Publish(context.Message.ToFailed());
        }
    }
}
