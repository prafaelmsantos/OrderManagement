namespace OrderManagement.API.Middlewares
{
    public class TrialMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly DateTime trialStart = new(2025, 11, 10); // início do trial
        private const int TrialDays = 2;

        public TrialMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            double daysUsed = (DateTime.UtcNow - trialStart).TotalDays;

            if (daysUsed > TrialDays)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Trial expirado");
                return;
            }

            await _next(context);
        }
    }
}
