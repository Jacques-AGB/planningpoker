using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Domain.Entities;

namespace planningpoker.Application.Features.Rules.Commands.AddRule;
public class AddRuleCommand : IRequest<Envelope<Rule>>
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
}
public class AddRuleCommandHandler : IRequestHandler<AddRuleCommand, Envelope<Rule>>
{
    private readonly IRuleRepository _repository;

    public AddRuleCommandHandler(IRuleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Envelope<Rule>> Handle(AddRuleCommand request, CancellationToken cancellationToken)
    {
        var Rule = await _repository.AddRule(request, cancellationToken);


        return Envelope<Rule>.Result.Ok(Rule);
    }
}