using BinaryPlate.Application.Common.Models;
using MediatR;
using planningpoker.Application.IRepository;
using planningpoker.Application.Responses.Rules;

namespace planningpoker.Application.Features.Rules.Queries.GetRule;
public class GetRuleByIdQuery : IRequest<Envelope<RuleResponse>>
{
    public string Id { get; set; }


    public class GetRuleByIdQueryHandler(IRuleRepository _repository) : IRequestHandler<GetRuleByIdQuery, Envelope<RuleResponse>>
    {
        public async Task<Envelope<RuleResponse>> Handle(GetRuleByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetRule(request.Id);

            return Envelope<RuleResponse>.Result.Ok(response);
        }
    }
}
