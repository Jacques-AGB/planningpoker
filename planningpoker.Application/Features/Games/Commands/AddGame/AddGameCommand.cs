using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Domain.Entities;
using planningpoker.Domain.Enums;

namespace planningpoker.Application.Features.Games.Commands.AddGame;
public class AddGameCommand : IRequest<Envelope<Game>>
{
    public string Name { get; set; }
    public Guid RuleId { get; set; }
    public int MaxPlayers { get; set; }
    public GameStatus Status { get; set; }
}
public class AddGameCommandHandler : IRequestHandler<AddGameCommand, Envelope<Game>>
{
    private readonly IGameRepository _repository;

    public AddGameCommandHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<Envelope<Game>> Handle(AddGameCommand request, CancellationToken cancellationToken)
    {
        var Game = await _repository.AddGame(request, cancellationToken);


        return Envelope<Game>.Result.Ok(Game);
    }
}