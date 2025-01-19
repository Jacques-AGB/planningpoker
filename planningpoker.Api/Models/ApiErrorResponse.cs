using System.Net;

namespace BinaryPlate.WebAPI.Models;


public class ApiErrorResponse
{
  
    public string Title { get; set; }


    public HttpStatusCode Status { get; set; }


    public string Type { get; set; }


    public string Instance { get; set; }

    public string ErrorMessage { get; set; }

    public string InnerException { get; set; }


    public string StackTrace { get; set; }


    public List<ValidationError> ValidationErrors { get; set; }


}