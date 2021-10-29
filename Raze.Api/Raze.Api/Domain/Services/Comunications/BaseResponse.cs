namespace Raze.Api.Domain.Services.Comunications
{
    public abstract class BaseResponse
    {
        protected BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; protected set; }
        public string Message { get; protected set; }
    }
}