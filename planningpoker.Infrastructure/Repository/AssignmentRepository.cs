using planningpoker.Application.Requests.AssignmentRequests;
using planningpoker.Application.Responses.AssignmentResponse;
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

    public async Task<Assignment> AddAssignment(AddAssignmentRequest request, CancellationToken cancellationToken)
    {
        var assignment = new Assignment
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Status = request.Status,

        };
        _context.Assignments.Add(assignment);
        await _context.SaveChangesAsync();
        
        return assignment;
    }
}
