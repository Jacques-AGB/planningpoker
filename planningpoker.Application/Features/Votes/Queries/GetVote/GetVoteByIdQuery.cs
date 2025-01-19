using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.Features.Votes.Queries.GetVote;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Votes;

namespace planningpoker.Application.Features.Votes.Queries.GetVote;
public class GetVoteByIdQuery : IRequest<Envelope<VoteResponse>>
{
    public string Id { get; set; }


    public class GetVoteByIdQueryHandler(IVoteRepository _repository) : IRequestHandler<GetVoteByIdQuery, Envelope<VoteResponse>>
    {
        public async Task<Envelope<VoteResponse>> Handle(GetVoteByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetVote(request.Id);

            return Envelope<VoteResponse>.Result.Ok(response);
        }
    }
}
