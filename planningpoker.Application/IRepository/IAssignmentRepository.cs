using planningpoker.Application.Features.Assignments.Commands.AddAssignment;
using planningpoker.Application.Responses.Assignments;
using planningpoker.Domain.Entities;

namespace planningpoker.Domain.IRepository;
public interface IAssignmentRepository
{
    Task<Assignment> AddAssignment(AddAssignmentCommand request, CancellationToken cancellationToken);
    Task<string> DeleteAssignment(Guid Id, CancellationToken cancellationToken);
    Task<AssignmentResponse> GetAssignment(string Id);
    Task<List<AssignmentResponse>> GetAssignments();
}
