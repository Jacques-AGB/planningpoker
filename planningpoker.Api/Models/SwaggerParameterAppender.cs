using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BinaryPlate.WebAPI.Models;


public class SwaggerParameterAppender : IOperationFilter
{


    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {

        operation.Parameters ??= new List<OpenApiParameter>();

        // Add a new parameter for Accept-Language header.
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Accept-Language",
            In = ParameterLocation.Header,
            Schema = new OpenApiSchema
            {
                Type = "String"
            },
            Required = false
        });
    }

}