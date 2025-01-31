namespace DeveloperStore.Api.Responses;

public class SuccessfullResponse<T>
{
    public string Message { get; set; }
    public T Data { get; set; }
    public int? TotalItems { get; set; }
    public int? CurrentPage { get; set; }
    public int? TotalPages { get; set; }
}