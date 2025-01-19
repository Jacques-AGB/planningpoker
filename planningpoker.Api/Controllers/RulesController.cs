using BinaryPlate.WebAPI.Controllers;
using BinaryPlate.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Application.Features.Rules.Commands.AddRule;
using planningpoker.Application.Features.Rules.Commands.DeleteRule;
using planningpoker.Application.Features.Rules.Queries.GetRule;
using planningpoker.Application.Features.Rules.Queries.GetRules;
using planningpoker.Application.Responses.Rules;
using planningpoker.Domain.Entities;

namespace planningpoker.Presentation.Api.Controllers;

[Route("api/[controller]")]
public class RuleController : ApiController
{

    [ProducesResponseType(typeof(ApiSuccessResponse<Rule>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpPost("AddRule")]
    public async Task<IActionResult> AddRule(AddRuleCommand request)
    {
        var response = await Sender.Send(request);
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<RuleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetRule")]
    public async Task<IActionResult> GetRule(string Id)
    {
        var response = await Sender.Send(new GetRuleByIdQuery() { Id = Id });
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<List<RuleResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetRules")]
    public async Task<IActionResult> GetRules()
    {
        var response = await Sender.Send(new GetRulesQuery());
        return TryGetResult(response);
    }


    [ProducesResponseType(typeof(ApiSuccessResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpDelete("DeleteRule")]
    public async Task<IActionResult> DeleteRule(Guid id)
    {
        var response = await Sender.Send(new DeleteRuleCommand { Id = id });
        return TryGetResult(response);
    }
}