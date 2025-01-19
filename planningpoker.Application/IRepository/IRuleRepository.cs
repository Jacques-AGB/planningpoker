using planningpoker.Application.Features.Rules.Commands.AddRule;
using planningpoker.Application.Responses.Rules;
using planningpoker.Domain.Entities;

namespace planningpoker.Application.IRepository;
public interface IRuleRepository
{
    Task<Rule> AddRule(AddRuleCommand request, CancellationToken cancellationToken);
    Task<string> DeleteRule(Guid Id, CancellationToken cancellationToken);
    Task<RuleResponse> GetRule(string Id);
    Task<List<RuleResponse>> GetRules();
}
