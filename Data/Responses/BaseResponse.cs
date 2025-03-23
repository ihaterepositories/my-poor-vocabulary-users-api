using Data.Responses.Enums;

namespace Data.Responses;

public class BaseResponse<T>
{
    public string? Description { get; set; }
    public StatusCode StatusCode { get; set; }
    public int ResultsCount { get; set; }
    public T? Data { get; set; }
}