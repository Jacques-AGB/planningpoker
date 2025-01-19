using BinaryPlate.WebAPI.Controllers;
using BinaryPlate.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Application.Features.Games.Commands.AddGame;
using planningpoker.Application.Features.Games.Commands.AddGame;
using planningpoker.Application.Features.Games.Commands.DeleteGame;
using planningpoker.Application.Features.Games.Queries.GetGame;
using planningpoker.Application.Features.Games.Queries.GetGames;
using planningpoker.Application.Responses.Game;
using planningpoker.Domain.Entities;

namespace planningpoker.Presentation.Api.Controllers;

[Route("api/[controller]")]
public class GamesController : ApiController
{

    [ProducesResponseType(typeof(ApiSuccessResponse<Game>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpPost("AddGame")]
    public async Task<IActionResult> AddGame(AddGameCommand request)
    {
        var response = await Sender.Send(request);
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<GameResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetGame")]
    public async Task<IActionResult> GetGame(string Id)
    {
        var response = await Sender.Send(new GetGameByIdQuery() { Id = Id });
        return TryGetResult(response);
    }

    [ProducesResponseType(typeof(ApiSuccessResponse<List<GameResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetGames")]
    public async Task<IActionResult> GetGames()
    {
        var response = await Sender.Send(new GetGamesQuery());
        return TryGetResult(response);
    }


    [ProducesResponseType(typeof(ApiSuccessResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    [HttpDelete("DeleteGame")]
    public async Task<IActionResult> DeleteGame(Guid id)
    {
        var response = await Sender.Send(new DeleteGameCommand { Id = id });
        return TryGetResult(response);
    }
}