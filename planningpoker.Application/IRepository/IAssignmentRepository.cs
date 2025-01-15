using planningpoker.Application.Requests.AssignmentRequests;
using planningpoker.Application.Responses.AssignmentResponse;
using planningpoker.Domain.Entities;

namespace planningpoker.Domain.IRepository;
public interface IAssignmentRepository
{

    Task<Assignment> AddAssignment(AddAssignmentRequest request, CancellationToken cancellationToken);
}
