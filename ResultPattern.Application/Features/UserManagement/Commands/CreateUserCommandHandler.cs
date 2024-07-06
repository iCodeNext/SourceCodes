using MediatR;
using ResultPattern.Application.Common.Interfaces;

namespace ResultPattern.Application.Features.UserManagement;
public class CreateUserCommandHandler(INotificationService notificationService)
    : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    private readonly INotificationService _notificationService = notificationService;

    public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        //Todo

        await _notificationService.Send("Messsage", request.Email);
        return new CreateUserResult(1221, request.Name);
    }
}

