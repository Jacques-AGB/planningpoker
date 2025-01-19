namespace BinaryPlate.WebAPI.Exceptions;

public class ApplicationResultException : Exception
{
  
    public ApplicationResultException() : base("Internal server error")
    {
    }

    public ApplicationResultException(string message) : base(message)
    {
    }

    public ApplicationResultException(IDictionary<string, string> validationErrors)
    {
        ValidationErrors = new Dictionary<string, string>(validationErrors);
    }

    public ApplicationResultException(string message, Exception innerException) : base(message, innerException)
    {
    }


    public Dictionary<string, string> ValidationErrors { get; protected set; }

}