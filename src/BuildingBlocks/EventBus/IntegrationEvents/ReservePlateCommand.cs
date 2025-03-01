namespace IntegrationEvents;

public class ReservePlateCommand(Guid PlateId) : IntegrationEvent
{
    public Guid PlateId { get; } = PlateId;
}


public class ReservePlateCommandFailed(Guid PlateId) 
{
    public Guid PlateId { get; } = PlateId;
}

public class ReservePlateCommandSucceeded(Guid PlateId) 
{
    public Guid PlateId { get; } = PlateId;
}

/// <summary>
/// These methods would also need to maintain the correlationId
/// </summary>
public static class ReservePlateCommandExtensions { 

    public static ReservePlateCommandSucceeded ToSucceeded(this ReservePlateCommand command)
    {
        return new ReservePlateCommandSucceeded(command.PlateId);
    }

    public static ReservePlateCommandFailed ToFailed(this ReservePlateCommand command)
    {
        return new ReservePlateCommandFailed(command.PlateId);
    }
}