using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.Responses.Assignments;
using planningpoker.Domain.IRepository;

namespace planningpoker.Application.Features.Assignments.Queries.GetAssignment;
public class GetAssignmentByIdQuery : IRequest<Envelope<AssignmentResponse>>
{
    public string Id { get; set; }


    public class GetAssignmentByIdQueryHandler(IAssignmentRepository _repository) : IRequestHandler<GetAssignmentByIdQuery, Envelope<AssignmentResponse>>
    {
        public async Task<Envelope<AssignmentResponse>> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAssignment(request.Id);

            return Envelope<AssignmentResponse>.Result.Ok(response);
        }
    }
}
