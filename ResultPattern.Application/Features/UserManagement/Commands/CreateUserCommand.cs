using MediatR;

namespace ResultPattern.Application.Features.UserManagement.Commands;
public record CreateUserCommand(int Id, string Name, string Email) : IRequest<bool>;