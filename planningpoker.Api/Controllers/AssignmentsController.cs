using MediatR;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Application.Features.Assignments.Commands;
using planningpoker.Domain.Entities;

namespace planningpoker.Presentation.Api.Controllers;

[Route("api/[controller]")]
public class AssignmentsController : ControllerBase
{
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [HttpPost("AddAssignment")]
    public async Task<Assignment> CreateClientType(AddAssignmentCommand command, ISender sender)
    {
        var response = await sender.Send(command);
        if(response == null) 
        {
            string message = "Failled to add assgnment's)";
            throw new ArgumentException(message);
        }
        return response;
    }
}
