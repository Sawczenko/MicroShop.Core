using MicroShop.Core.Errors;

namespace MicroShop.Core.Models.Requests;

public abstract class RequestResultBase
{

    public readonly string Message;

    public readonly bool IsSuccessful;

    public bool IsFailure => !IsSuccessful;

    public readonly Error Error;

    protected RequestResultBase(bool isSuccessful, Error error)
    {
        IsSuccessful = isSuccessful;
        Error = error;
        Message = error.GetMessage();
    }

    protected RequestResultBase(bool isSuccessful, Error error, string message)
    {
        IsSuccessful = isSuccessful;
        Error = error;
        Message = message;
    }

    protected RequestResultBase(bool isSuccessful, Error error, params string[] errorParameters) : this(isSuccessful, error)
    {   
        if (!isSuccessful)
        {
            Message = CreateParametrizedMessage(errorParameters);
        }
    }

    public string CreateParametrizedMessage (params string[] parameters)
    {
        string message = Message;

        if (parameters.Any())
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                message = message.Replace("{" + i + "}", parameters[i]);
            }
        }

        return message;
    }
}


public class RequestResult : RequestResultBase
{
    private RequestResult(bool isSuccessful, Error error) : base(isSuccessful, error)
    { }

    private RequestResult(bool isSuccessful, Error error, string message) : base(isSuccessful, error)
    {
    }

    private RequestResult(bool isSuccessful, Error error, params string[] parameters) : base(isSuccessful, error, parameters) { }

    public static RequestResult Success() => new(true, Error.ERROR_NONE);

    public static RequestResult Failure(Error error, params string[] parameters) => new(false, error, parameters);
}

public class RequestResult<T> : RequestResultBase
{
    public readonly T Result;

    private RequestResult(T result, bool isSuccessful, Error error, string message) : base(isSuccessful, error, message)
    {
        Result = result;
    }

    private RequestResult(T result, bool isSuccessful, Error error, params string[] parameters) : base(isSuccessful, error, parameters)
    {
        Result = result;
    }

    public static RequestResult<T> Success(T result) => new RequestResult<T>(result, true, Error.ERROR_NONE);

    public static RequestResult<T> Failure(Error error, params string[] parameters) => new(default, false, error, parameters);

    public static RequestResult<T> Failure(RequestResult requestResult)
    {
        return new RequestResult<T>(default, requestResult.IsSuccessful, requestResult.Error, requestResult.Message);
    }
}