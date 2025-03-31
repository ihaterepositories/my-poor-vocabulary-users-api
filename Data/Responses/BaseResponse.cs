using Data.Responses.Enums;

namespace Data.Responses;

public class BaseResponse<T>
{
    public string? ErrorDescription { get; set; }
    public StatusCode StatusCode { get; set; }
    public T? Data { get; set; }
}