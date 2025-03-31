using Data.Responses.Enums;

namespace Data.Responses;

public class NoReturnDataResponse
{
    public string? ErrorDescription { get; set; }
    public StatusCode StatusCode { get; set; }
}