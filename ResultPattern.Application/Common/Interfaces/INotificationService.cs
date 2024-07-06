namespace ResultPattern.Application.Common.Interfaces;
public interface INotificationService
{
    Task<bool> Send(string message, string email);
}
