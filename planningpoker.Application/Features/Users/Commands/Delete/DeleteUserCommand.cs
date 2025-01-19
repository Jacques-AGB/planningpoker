using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;

namespace planningpoker.Application.Features.Users.Commands.Delete;
public class DeleteUserCommand : IRequest<Envelope<string>>
{
    public Guid Id { get; set; }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Envelope<string>>
{
    private readonly IUserRepository _repository;

    public DeleteUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<Envelope<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.DeleteUser(request.Id, cancellationToken);

        return Envelope<string>.Result.Ok(response);
    }
}