using planningpoker.Application.Features.Votes.Commands.AddVote;
using planningpoker.Application.Responses.Votes;
using planningpoker.Domain.Entities;

namespace planningpoker.Application.IRepository;
public interface IVoteRepository
{
    Task<Vote> AddVote(AddVoteCommand request, CancellationToken cancellationToken);
    Task<string> DeleteVote(Guid Id, CancellationToken cancellationToken);
    Task<VoteResponse> GetVote(string Id);
    Task<List<VoteResponse>> GetVotes();
}