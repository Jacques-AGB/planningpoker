
using System.Collections.Concurrent;
using System.Net;

namespace BinaryPlate.Application.Common.Models;

/// <summary>
/// Envelope that wraps an HTTP response and includes a payload of type TResponse.
/// </summary>
/// <typeparam name="TResponse">The type of the payload.</typeparam>
public class Envelope<TResponse> : EnvelopeBase
{

    private static readonly ConcurrentDictionary<Type, object> _payload = new();

    public Envelope(Dictionary<string, string> keyValuePairs) : base(keyValuePairs)
    {
    }

    public Envelope(TResponse payload) : this(null)
    {
        IsError = false;
        Payload = payload;
    }


    private Envelope()
    {
        IsError = false;
        Title = string.Empty;
        ValidationErrors = new Dictionary<string, string>();
    }

    public static Envelope<TResponse> Result
    {
        get
        {
            var type = typeof(Envelope<TResponse>);
            if (_payload.TryGetValue(type, out var payload))
                return (Envelope<TResponse>)payload;

            var newPayload = new Envelope<TResponse>();
            _payload.TryAdd(type, newPayload);
            return newPayload;
        }
    }


    public TResponse Payload { get; private set; }

  
    public bool RollbackDisabled { get; private set; }




    public Envelope<TResponse> Ok(TResponse payload)
    {
        IsError = false;
        ValidationErrors = new Dictionary<string, string>();
        Title = "Success";
        Payload = payload;
        return this;
    }

    public Envelope<TResponse> ServerError(string title = "Internal Server Error", bool rollbackDisabled = false)
    {
        IsError = true;
        RollbackDisabled = rollbackDisabled;
        ValidationErrors = new Dictionary<string, string>();
        Title = title;
        return this;
    }


    public Envelope<TResponse> NotFound(string title = "Not Found", bool rollbackDisabled = false)
    {
        IsError = true;
        RollbackDisabled = rollbackDisabled;
        ValidationErrors = new Dictionary<string, string>();
        HttpStatusCode = HttpStatusCode.NotFound;
        Title = title;
        return this;
    }


    public Envelope<TResponse> BadRequest(string title = "Bad Request", bool rollbackDisabled = false)
    {
        IsError = true;
        RollbackDisabled = rollbackDisabled;
        ValidationErrors = new Dictionary<string, string>();
        HttpStatusCode = HttpStatusCode.BadRequest;
        Title = title;
        return this;
    }


    public Envelope<TResponse> AddErrors(Dictionary<string, string> keyValuePairs, HttpStatusCode httpStatusCode, string message = null, bool rollbackDisabled = false)
    {
        IsError = true;
        RollbackDisabled = rollbackDisabled;
        Title = message;
        HttpStatusCode = httpStatusCode;
        ValidationErrors = new Dictionary<string, string>(keyValuePairs);
        return this;
    }

    public Envelope<TResponse> Unauthorized(string title, bool rollbackDisabled = false)
    {
        IsError = true;
        RollbackDisabled = rollbackDisabled;
        ValidationErrors = new Dictionary<string, string>();
        HttpStatusCode = HttpStatusCode.Unauthorized;
        Title = title;
        return this;
    }

 
    public Envelope<TResponse> Forbidden(string title, bool rollbackDisabled = false)
    {
        IsError = true;
        RollbackDisabled = rollbackDisabled;
        ValidationErrors = new Dictionary<string, string>();
        HttpStatusCode = HttpStatusCode.Forbidden;
        Title = title;
        return this;
    }

  
}