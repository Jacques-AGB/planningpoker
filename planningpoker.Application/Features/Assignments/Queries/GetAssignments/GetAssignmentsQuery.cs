using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.Responses.Assignments;
using planningpoker.Domain.IRepository;

namespace planningpoker.Application.Features.Assignments.Queries.GetAssignments;
public class GetAssignmentsQuery : IRequest<Envelope<List<AssignmentResponse>>>
{

    public class GetAssignmentQueryHandler(IAssignmentRepository repository) : IRequestHandler<GetAssignmentsQuery, Envelope<List<AssignmentResponse>>>
    {
        public async Task<Envelope<List<AssignmentResponse>>> Handle(GetAssignmentsQuery request, CancellationToken cancellationToken)
        {
            var response = await repository.GetAssignments();
            return Envelope<List<AssignmentResponse>>.Result.Ok(response);
        }
    }
}