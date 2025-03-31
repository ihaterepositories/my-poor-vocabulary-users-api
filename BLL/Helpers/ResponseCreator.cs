using Data.Responses;
using Data.Responses.Enums;

namespace BLL.Helpers;

public class ResponseCreator
{
    /// <summary>
    /// Response for POST/PUT/DELETE queries with no return data.
    /// </summary>
    public NoReturnDataResponse CreateOk()
    {
        return new NoReturnDataResponse
        {
            ErrorDescription = "No errors.",
            StatusCode = StatusCode.Ok
        };
    }
    
    public BaseResponse<T> CreateOk<T>(T returnData)
    {
        return new BaseResponse<T>
        {
            Data = returnData,
            ErrorDescription = "No errors.",
            StatusCode = StatusCode.Ok
        };
    }
    
    public NoReturnDataResponse CreateBadRequest(string errorDescription)
    {
        return new NoReturnDataResponse
        {
            ErrorDescription = errorDescription,
            StatusCode = StatusCode.BadRequest
        };
    }
    
    public BaseResponse<T> CreateBadRequest<T>(string errorDescription)
    {
        return new BaseResponse<T>
        {
            Data = default!,
            ErrorDescription = errorDescription,
            StatusCode = StatusCode.BadRequest
        };
    }
    
    public NoReturnDataResponse CreateNotFound(string errorDescription)
    {
        return new NoReturnDataResponse
        {
            ErrorDescription = errorDescription,
            StatusCode = StatusCode.NotFound
        };
    }
    
    public BaseResponse<T> CreateNotFound<T>(string errorDescription)
    {
        return new BaseResponse<T>
        {
            Data = default!,
            ErrorDescription = errorDescription,
            StatusCode = StatusCode.NotFound
        };
    }
    
    public NoReturnDataResponse CreateServerError(string exceptionMessage)
    {
        return new NoReturnDataResponse
        {
            ErrorDescription = "Server error, caught exception: " + exceptionMessage,
            StatusCode = StatusCode.InternalServerError
        };
    }
    
    public BaseResponse<T> CreateServerError<T>(string exceptionMessage)
    {
        return new BaseResponse<T>
        {
            Data = default!,
            ErrorDescription = "Server error, caught exception: " + exceptionMessage,
            StatusCode = StatusCode.InternalServerError
        };
    }
}