using MicroShop.Core.Errors;

namespace MicroShop.Core.Models.Requests
{
    public class RequestResultBase
{
    public RequestResultBase(bool isSuccessful, Error error)
    {
        IsSuccessful = isSuccessful;
        Error = error;
    }

    public RequestResultBase(bool isSuccessful, Error error, params string[] errorParameters) : this(isSuccessful, error)
    {
        if (!isSuccessful)
        {
            error.ParametrizeMessage(errorParameters);
        }
    }

    public bool IsSuccessful { get; }

    public bool IsFailure => !IsSuccessful;

    public Error Error { get; }
}


public class RequestResult : RequestResultBase
{
    private RequestResult(bool isSuccessful, Error error) : base(isSuccessful, error)
    { }

    private RequestResult(bool isSuccessful, Error error, params string[] parameters) : base(isSuccessful, error, parameters) { }

    public static RequestResult Success() => new(true, Error.ERROR_NONE);

    public static RequestResult Failure(Error error, params string[] parameters) => new(false, error, parameters);
}

public class RequestResult<T> : RequestResultBase
{
    private RequestResult(T result, bool isSuccessful, Error error) : base(isSuccessful, error)
    {
        Result = result;
    }

    private RequestResult(T result, bool isSuccessful, Error error, params string[] paramaters) : base(isSuccessful, error, paramaters)
    {
        Result = result;
    }

    public T Result { get; }

    public static RequestResult<T> Success(T result) => new RequestResult<T>(result, true, Error.ERROR_NONE);

    public static RequestResult<T> Failure(Error error, params string[] parameters) => new(default, false, error, parameters);

    public static RequestResult<T> Failure(RequestResult requestResult)
    {
        return new RequestResult<T>(default, requestResult.IsSuccessful, requestResult.Error);
    }
}
}
