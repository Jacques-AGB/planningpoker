using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;

namespace planningpoker.Application.Features.Games.Commands.DeleteGame;
public class DeleteGameCommand : IRequest<Envelope<string>>
{
    public Guid Id { get; set; }
}

public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, Envelope<string>>
{
    private readonly IGameRepository _repository;

    public DeleteGameCommandHandler(IGameRepository repository)
    {
        _repository = repository;
    }
    public async Task<Envelope<string>> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.DeleteGame(request.Id, cancellationToken);

        return Envelope<string>.Result.Ok(response);
    }
}