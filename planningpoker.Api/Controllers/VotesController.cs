using BinaryPlate.WebAPI.Controllers;
using BinaryPlate.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Application.Features.Votes.Commands.AddVote;
using planningpoker.Application.Features.Votes.Commands.DeleteVote;
using planningpoker.Application.Features.Votes.Queries.GetVote;
using planningpoker.Application.Features.Votes.Queries.GetVotes;
using planningpoker.Application.Responses.Votes;
using planningpoker.Domain.Entities;

namespace planningpoker.Presentation.Api.Controllers;

[Route("api/[controller]")]
public class VotesController : ApiController
{

    [ProducesResponseType(typeof(ApiSuccessResponse<Vote>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpPost("AddVote")]
    public async Task<IActionResult> AddVote(AddVoteCommand request)
    {
        var response = await Sender.Send(request);
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<VoteResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetVote")]
    public async Task<IActionResult> GetVote(string Id)
    {
        var response = await Sender.Send(new GetVoteByIdQuery() { Id = Id });
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<List<VoteResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetVotes")]
    public async Task<IActionResult> GetVotes()
    {
        var response = await Sender.Send(new GetVotesQuery());
        return TryGetResult(response);
    }


    [ProducesResponseType(typeof(ApiSuccessResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpDelete("DeleteVote")]
    public async Task<IActionResult> DeleteVote(Guid id)
    {
        var response = await Sender.Send(new DeleteVoteCommand { Id = id });
        return TryGetResult(response);
    }
}