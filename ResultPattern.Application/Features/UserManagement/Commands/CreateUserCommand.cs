using MediatR;

namespace ResultPattern.Application.Features.UserManagement;
public record CreateUserCommand(string Name, string Email) : IRequest<CreateUserResult>;


public record CreateUserResult(int UserId, string Name);