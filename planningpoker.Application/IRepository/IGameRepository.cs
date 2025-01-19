using planningpoker.Application.Features.Games.Commands.AddGame;
using planningpoker.Application.Responses.Game;
using planningpoker.Domain.Entities;

namespace planningpoker.Application.IRepository;
public interface IGameRepository
{
    Task<Game> AddGame(AddGameCommand request, CancellationToken cancellationToken);
    Task<string> DeleteGame(Guid Id, CancellationToken cancellationToken);
    Task<GameResponse> GetGame(string Id);
    Task<List<GameResponse>> GetGames();
}
