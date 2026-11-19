using System.Diagnostics;

namespace WebApplication3.Custom_MiddleWare
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var Watch = Stopwatch.StartNew();
            await _next(context);
            Watch.Stop();
            Console.WriteLine($"{context.Request.Path}: {Watch.ElapsedMilliseconds}ms");
        }
    }
}
