using BinaryPlate.WebAPI.Controllers;
using BinaryPlate.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Application.Features.Assignments.Commands.AddAssignment;
using planningpoker.Application.Features.Assignments.Commands.DeleteAssignment;
using planningpoker.Application.Features.Assignments.Queries.GetAssignment;
using planningpoker.Application.Features.Assignments.Queries.GetAssignments;
using planningpoker.Application.Responses.Assignments;
using planningpoker.Domain.Entities;

namespace planningpoker.Presentation.Api.Controllers;


[Route("api/[controller]")]
public class AssignmentsController : ApiController
{

    [ProducesResponseType(typeof(ApiSuccessResponse<Assignment>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpPost("AddAssignment")]
    public async Task<IActionResult> AddAssignment(AddAssignmentCommand request)
    {
        var response = await Sender.Send(request);
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<AssignmentResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetAssignment")]
    public async Task<IActionResult> GetAssignment(string Id)
    {
        var response = await Sender.Send(new GetAssignmentByIdQuery() { Id = Id });
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<List<AssignmentResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetAssignments")]
    public async Task<IActionResult> GetAssignments()
    {
        var response = await Sender.Send(new GetAssignmentsQuery());
        return TryGetResult(response);
    }


    [ProducesResponseType(typeof(ApiSuccessResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpDelete("DeleteAssignment")]
    public async Task<IActionResult> DeleteAssignment(Guid id)
    {
        var response = await Sender.Send(new DeleteAssignmentCommand { Id = id });
        return TryGetResult(response);
    }
}