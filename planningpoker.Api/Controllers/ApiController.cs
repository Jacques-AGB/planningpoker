using BinaryPlate.Application.Common.Models;
using BinaryPlate.WebAPI.Exceptions;
using BinaryPlate.WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BinaryPlate.WebAPI.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{


    private ISender _sender;
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();

   
    protected IActionResult TryGetResult<T>(Envelope<T> envelope)
    {
        ThrowExceptionsIfExist(envelope);

        var apiResponse = new ApiSuccessResponse<T>(envelope, HttpContext.Request.Path);

        return Ok(apiResponse);
    }

  
    private static void ThrowExceptionsIfExist(EnvelopeBase envelope)
    {
        switch (envelope.IsError)
        {
            case true when envelope.ValidationErrors.Any():
                throw new ApplicationResultException(envelope.ValidationErrors);
            case true:
                throw envelope.HttpStatusCode switch
                {
                    HttpStatusCode.Unauthorized => new UnauthorizedAccessException(envelope.Title),
                    HttpStatusCode.NotFound => new NotFoundException(envelope.Title),
                    HttpStatusCode.BadRequest => new BadRequestException(envelope.Title),
                    _ => new InternalServerException(envelope.Title)
                };
        }
    }

   
}