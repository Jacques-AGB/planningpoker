using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;

namespace planningpoker.Application.Features.Roles.Commands.DeleteRole;
public class DeleteRoleCommand : IRequest<Envelope<string>>
{
    public Guid Id { get; set; }
}

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Envelope<string>>
{
    private readonly IRoleRepository _repository;

    public DeleteRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }
    public async Task<Envelope<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.DeleteRole(request.Id, cancellationToken);

        return Envelope<string>.Result.Ok(response);
    }
}