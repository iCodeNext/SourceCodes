using ResultPattern.Application.Common.Interfaces;

namespace ResultPattern.Infrastructure;

public class NotificationService : INotificationService
{
    public Task<bool> Send(string message, string email)
    {
        Random random = new();
        if (random.Next(1, 10) % 2 == 0)
        {
            throw new Exception("Invalid Operation");
        }

        return Task.FromResult(true);
    }
}
