using System;

namespace BsButtonApi.Data.ResultModels
{
    public static class MethodResultExtension
    {
        public static MethodResult AddErrorMessage(this MethodResult methodResult, string errorMessage)
        {
            methodResult.IsSuccess = false;
            methodResult.Message = string.IsNullOrWhiteSpace(methodResult.Message)
                ? errorMessage
                : $"{methodResult.Message}{Environment.NewLine}{errorMessage}";
            return methodResult;
        }

        public static MethodResultValue<T> AddErrorMessage<T>(this MethodResultValue<T> methodResult,
            string errorMessage)
        {
            methodResult.IsSuccess = false;
            methodResult.Message = string.IsNullOrWhiteSpace(methodResult.Message)
                ? errorMessage
                : $"{methodResult.Message}{Environment.NewLine}{errorMessage}";
            return methodResult;
        }
    }
}