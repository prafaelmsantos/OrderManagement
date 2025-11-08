namespace OrderManagement.API.Middlewares.Interfaces
{
    public interface IErrorHandlerMiddleware
    {
        Task InvokeAsync(HttpContext context);
    }
}
