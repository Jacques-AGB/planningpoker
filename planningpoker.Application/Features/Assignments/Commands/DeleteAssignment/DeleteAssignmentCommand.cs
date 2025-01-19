using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Domain.IRepository;

namespace planningpoker.Application.Features.Assignments.Commands.DeleteAssignment;
public class DeleteAssignmentCommand : IRequest<Envelope<string>>
{
    public Guid Id { get; set; }
}

public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand, Envelope<string>>
{
    private readonly IAssignmentRepository _repository;

    public DeleteAssignmentCommandHandler(IAssignmentRepository repository)
    {
        _repository = repository;
    }
    public async Task<Envelope<string>> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.DeleteAssignment(request.Id, cancellationToken);

        return Envelope<string>.Result.Ok(response);
    }
}