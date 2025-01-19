using Microsoft.EntityFrameworkCore;
using planningpoker.Application.Features.Assignments.Commands.AddAssignment;
using planningpoker.Application.Responses.Assignments;
using planningpoker.Domain.Entities;
using planningpoker.Domain.IRepository;
using planningpoker.Infrastructure.Persistence.PostgreSql;

namespace planningpoker.Infrastructure.Repository;
public class AssignmentRepository : IAssignmentRepository
{

    private readonly PostgreSqlApplicationDbContext _context;

    public AssignmentRepository(PostgreSqlApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Assignment> AddAssignment(AddAssignmentCommand request, CancellationToken cancellationToken)
    {
        var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == request.GameId);
        if (game == null)
        {
            string message = $"Game with id {request.GameId} doesn't exist";
            throw new ApplicationException(message);
        }
        var assignment = new Assignment
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            GameId = request.GameId,
            Status = request.Status

        };
        _context.Assignments.Add(assignment);
        await _context.SaveChangesAsync();
        Console.WriteLine(assignment);

        return assignment;
    }

    public async Task<string> DeleteAssignment(Guid Id, CancellationToken cancellationToken)
    {
        var assignment = await _context.Assignments.FindAsync(Id);
        if (assignment == null)
        {
            string message = $" Assignment with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        else
        {
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync(cancellationToken);
            return $"Assignment with Id '{Id}' has been deleted successfully";
        }
    }

    public async Task<AssignmentResponse> GetAssignment(string Id)
    {
        var assignment = await _context.Assignments.FirstOrDefaultAsync(r => r.Id.ToString() == Id);
        if (assignment == null)
        {
            string message = $" Assignment with Id {Id} doesn't exist";
            throw new ApplicationException(message);
        }
        var response = new AssignmentResponse
        {
            Id = assignment.Id,
            Description = assignment.Description,
            Status = assignment.Status,
            Votes = assignment.Votes
        };

        return response;
    }

    public async Task<List<AssignmentResponse>> GetAssignments()
    {
        var assignment = await _context.Assignments.Select(assignment => new AssignmentResponse
        {
            Id = assignment.Id,
            Description = assignment.Description,
            Status = assignment.Status,
            Votes = assignment.Votes
        }).ToListAsync();

        return assignment;
    }

}
