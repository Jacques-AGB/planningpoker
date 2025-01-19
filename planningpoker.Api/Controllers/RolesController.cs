using BinaryPlate.WebAPI.Controllers;
using BinaryPlate.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Application.Features.Roles.Commands.AddRole;
using planningpoker.Application.Features.Roles.Commands.DeleteRole;
using planningpoker.Application.Features.Roles.Queries.GetRole;
using planningpoker.Application.Features.Roles.Queries.GetRoles;
using planningpoker.Application.Responses.Role;
using planningpoker.Domain.Entities;

namespace planningpoker.Presentation.Api.Controllers;


[Route("api/[controller]")]
public class RolesController : ApiController
{

    [ProducesResponseType(typeof(ApiSuccessResponse<Role>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpPost("AddRole")]
    public async Task<IActionResult> AddRole(AddRoleCommand request)
    {
        var response = await Sender.Send(request);
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<RoleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetRole")]
    public async Task<IActionResult> GetRole(string Id)
    {
        var response = await Sender.Send(new GetRoleByIdQuery() { Id = Id });
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<List<RoleResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetRoles")]
    public async Task<IActionResult> GetRoles()
    {
        var response = await Sender.Send(new GetRolesQuery());
        return TryGetResult(response);
    }


    [ProducesResponseType(typeof(ApiSuccessResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpDelete("DeleteRole")]
    public async Task<IActionResult> DeleteRole(Guid id)
    {
        var response = await Sender.Send(new DeleteRoleCommand { Id = id });
        return TryGetResult(response);
    }
}