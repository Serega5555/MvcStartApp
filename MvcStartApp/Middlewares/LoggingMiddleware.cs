using MvcStartApp.Controllers;
using MvcStartApp.Repositories;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repo;

        public LoggingMiddleware(RequestDelegate next, IRequestRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var date = DateTime.Now;
            
            Console.WriteLine($"[{date}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            
            await _next.Invoke(context);

            await _repo.AddRequest(date, context);
        }
    }
}
