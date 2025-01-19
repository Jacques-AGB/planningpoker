using System.Net;

namespace BinaryPlate.Application.Common.Models;

public abstract class EnvelopeBase
{

    protected EnvelopeBase()
    {
        IsError = false;
        Title = string.Empty;
        ValidationErrors = new Dictionary<string, string>();
    }

    protected EnvelopeBase(Dictionary<string, string> keyValuePairs)
    {
        IsError = true;
        Title = null;
        ValidationErrors = keyValuePairs;
    }

    public bool IsError { get; protected set; }

    public HttpStatusCode HttpStatusCode { get; protected set; }

    public string Title { get; protected set; }

    public Dictionary<string, string> ValidationErrors { get; protected set; }


}