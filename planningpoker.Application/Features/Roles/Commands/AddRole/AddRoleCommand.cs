using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Domain.Entities;

namespace planningpoker.Application.Features.Roles.Commands.AddRole;
public class AddRoleCommand : IRequest<Envelope<Role>>
{
    public string Name { get; set; } = "";
}
public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Envelope<Role>>
{
    private readonly IRoleRepository _repository;

    public AddRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Envelope<Role>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var Role = await _repository.AddRole(request, cancellationToken);


        return Envelope<Role>.Result.Ok(Role);
    }
}