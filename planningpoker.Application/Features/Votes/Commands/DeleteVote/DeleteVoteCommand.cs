using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.Features.Rules.Commands.DeleteRule;
using planningpoker.Application.IRepository;

namespace planningpoker.Application.Features.Votes.Commands.DeleteVote;
public class DeleteVoteCommand : IRequest<Envelope<string>>
{
    public Guid Id { get; set; }
}

public class DeleteRuleCommandHandler : IRequestHandler<DeleteRuleCommand, Envelope<string>>
{
    private readonly IRuleRepository _repository;

    public DeleteRuleCommandHandler(IRuleRepository repository)
    {
        _repository = repository;
    }
    public async Task<Envelope<string>> Handle(DeleteRuleCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.DeleteRule(request.Id, cancellationToken);

        return Envelope<string>.Result.Ok(response);
    }
}