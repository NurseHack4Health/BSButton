namespace BsButtonApi.Data.ResultModels
{
    public class MethodResult
    {
        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = string.Empty;
    }
}