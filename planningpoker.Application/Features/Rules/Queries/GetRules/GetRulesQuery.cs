using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Rules;

namespace planningpoker.Application.Features.Rules.Queries.GetRules;
public class GetRulesQuery : IRequest<Envelope<List<RuleResponse>>>
{

    public class GetRuleQueryHandler(IRuleRepository repository) : IRequestHandler<GetRulesQuery, Envelope<List<RuleResponse>>>
    {
        public async Task<Envelope<List<RuleResponse>>> Handle(GetRulesQuery request, CancellationToken cancellationToken)
        {
            var response = await repository.GetRules();
            return Envelope<List<RuleResponse>>.Result.Ok(response);
        }
    }
}
