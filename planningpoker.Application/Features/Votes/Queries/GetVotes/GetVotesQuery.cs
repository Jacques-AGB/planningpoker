using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Votes;

namespace planningpoker.Application.Features.Votes.Queries.GetVotes;
public class GetVotesQuery : IRequest<Envelope<List<VoteResponse>>>
{

    public class GetVoteQueryHandler(IVoteRepository repository) : IRequestHandler<GetVotesQuery, Envelope<List<VoteResponse>>>
    {
        public async Task<Envelope<List<VoteResponse>>> Handle(GetVotesQuery request, CancellationToken cancellationToken)
        {
            var response = await repository.GetVotes();
            return Envelope<List<VoteResponse>>.Result.Ok(response);
        }
    }
}
