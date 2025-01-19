using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Game;

namespace planningpoker.Application.Features.Games.Queries.GetGames;
public class GetGamesQuery : IRequest<Envelope<List<GameResponse>>>
{

    public class GetGameQueryHandler(IGameRepository repository) : IRequestHandler<GetGamesQuery, Envelope<List<GameResponse>>>
    {
        public async Task<Envelope<List<GameResponse>>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            var response = await repository.GetGames();
            return Envelope<List<GameResponse>>.Result.Ok(response);
        }
    }
}