using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Game;

namespace planningpoker.Application.Features.Games.Queries.GetGame;
public class GetGameByIdQuery : IRequest<Envelope<GameResponse>>
{
    public string Id { get; set; }


    public class GetGameByIdQueryHandler(IGameRepository _repository) : IRequestHandler<GetGameByIdQuery, Envelope<GameResponse>>
    {
        public async Task<Envelope<GameResponse>> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetGame(request.Id);

            return Envelope<GameResponse>.Result.Ok(response);
        }
    }
}
