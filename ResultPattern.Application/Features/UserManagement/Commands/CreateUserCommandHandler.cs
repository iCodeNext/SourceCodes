using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultPattern.Application.Features.UserManagement.Commands;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    public CreateUserCommandHandler()
    {
    }

    public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        
    }
}