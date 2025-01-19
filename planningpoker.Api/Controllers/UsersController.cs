using BinaryPlate.WebAPI.Controllers;
using BinaryPlate.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Application.Features.Users.Commands.AddUser;
using planningpoker.Application.Features.Users.Commands.Delete;
using planningpoker.Application.Features.Users.Queries.GetUser;
using planningpoker.Application.Features.Users.Queries.GetUsers;
using planningpoker.Application.Responses.Users;
using planningpoker.Domain.Entities;

namespace planningpoker.Presentation.Api.Controllers;

[Route("api/[controller]")]
public class UsersController : ApiController
{

    [ProducesResponseType(typeof(ApiSuccessResponse<User>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser(AddUserCommand request)
    {
        var response = await Sender.Send(request);
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<UserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUser(string Id)
    {
        var response = await Sender.Send(new GetUserByIdQuery() { Id = Id });
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<List<UserResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var response = await Sender.Send(new GetUsersQuery());
        return TryGetResult(response);
    }


    [ProducesResponseType(typeof(ApiSuccessResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var response = await Sender.Send(new DeleteUserCommand { Id = id });
        return TryGetResult(response);
    }
}