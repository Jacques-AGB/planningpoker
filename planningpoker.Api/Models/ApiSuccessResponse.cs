using BinaryPlate.Application.Common.Models;
using System.Net;

namespace BinaryPlate.WebAPI.Models;

public class ApiSuccessResponse<T>
{

    public ApiSuccessResponse(Envelope<T> response, PathString path)
    {
        Status = (int)HttpStatusCode.OK;
        Type = "https://httpstatuses.com/200";
        Instance = path;
        Payload = response.Payload;
    }

    public int Status { get; set; }

    public string Type { get; set; }


    public string Instance { get; set; }

    public T Payload { get; set; }


}