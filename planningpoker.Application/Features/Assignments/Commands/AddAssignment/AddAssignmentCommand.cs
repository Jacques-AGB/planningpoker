using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Domain.Entities;
using planningpoker.Domain.Enums;
using planningpoker.Domain.IRepository;
namespace planningpoker.Application.Features.Assignments.Commands.AddAssignment;
public class AddAssignmentCommand : IRequest<Envelope<Assignment>>
{
    public string Description { get; set; }
    public Guid GameId { get; set; }
    public AssignmentStatus Status { get; set; }
}
public class AddAssignmentCommandHandler : IRequestHandler<AddAssignmentCommand, Envelope<Assignment>>
{
    private readonly IAssignmentRepository _repository;

    public AddAssignmentCommandHandler(IAssignmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Envelope<Assignment>> Handle(AddAssignmentCommand request, CancellationToken cancellationToken)
    {
        var assignment = await _repository.AddAssignment(request, cancellationToken);


        return Envelope<Assignment>.Result.Ok(assignment);
    }
}