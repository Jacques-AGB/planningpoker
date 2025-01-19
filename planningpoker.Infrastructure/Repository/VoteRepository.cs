using MediatR;
using Microsoft.EntityFrameworkCore;
using planningpoker.Application.Features.Votes.Commands.AddVote;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Votes;
using planningpoker.Domain.Entities;
using planningpoker.Infrastructure.Persistence.PostgreSql;

namespace planningpoker.Infrastructure.Repository;
public class VoteRepository : IVoteRepository
{
    private readonly PostgreSqlApplicationDbContext _context;

    public VoteRepository(PostgreSqlApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Vote> AddVote(AddVoteCommand request, CancellationToken cancellationToken)
    {
        var Vote = new Vote
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            AssignmentId = request.AssignmentId,
            Value = request.Value

        };
        _context.Votes.Add(Vote);
        await _context.SaveChangesAsync();
        Console.WriteLine(Vote);

        return Vote;
    }


    public async Task<string> DeleteVote(Guid Id, CancellationToken cancellationToken)
    {
        var vote = await _context.Votes.FindAsync(Id);
        if (vote == null)
        {
            string message = $" Vote with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        else
        {
            _context.Votes.Remove(vote);
            await _context.SaveChangesAsync(cancellationToken);
            return $"Vote with Id '{Id}' has been deleted successfully";
        }
    }

    public async Task<VoteResponse> GetVote(string Id)
    {
        var Vote = await _context.Votes.FirstOrDefaultAsync(r => r.Id.ToString() == Id);
        if (Vote == null)
        {
            string message = $" Vote with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        var response = new VoteResponse
        {
            Id = Vote.Id,
            UserId = Vote.UserId,
            AssignmentId = Vote.AssignmentId,
            Value = Vote.Value

        };

        return response;
    }

    public async Task<List<VoteResponse>> GetVotes()
    {
        var Vote = await _context.Votes.Select(Vote => new VoteResponse
        {
            Id = Guid.NewGuid(),
            UserId = Vote.UserId,
            AssignmentId = Vote.AssignmentId,
            Value = Vote.Value
        }).ToListAsync();

        return Vote;
    }


}