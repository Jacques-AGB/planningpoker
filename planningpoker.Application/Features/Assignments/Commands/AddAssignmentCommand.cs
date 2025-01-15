using MediatR;
using planningpoker.Application.Requests.AssignmentRequests;
using planningpoker.Domain.Entities;
using planningpoker.Domain.IRepository;
namespace planningpoker.Application.Features.Assignments.Commands;
public class AddAssignmentCommand : IRequest<Assignment>
{
    public AddAssignmentRequest addAssignment { get; set; }
}

public class AddAssignmentCommandHandler : IRequestHandler<AddAssignmentCommand, Assignment>
{
    private readonly IAssignmentRepository _repository;

    public AddAssignmentCommandHandler(IAssignmentRepository repository)
    {
        _repository = repository;
    }
    public async Task<Assignment> Handle(AddAssignmentCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.AddAssignment(request.addAssignment, cancellationToken);
        return response;
    }

   
}

