namespace BsButtonApi.Data.ResultModels
{
    public class MethodResultValue<T> : MethodResult
    {
        public T ReturnValue { get; set; }
    }
}