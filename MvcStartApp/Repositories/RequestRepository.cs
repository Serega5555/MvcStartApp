using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MvcStartApp.Models.Db;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcStartApp.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _blogContext;

        public RequestRepository(BlogContext blogContex)
        {
            _blogContext = blogContex;
        }

        public async Task AddRequest(DateTime date, HttpContext context)
        {
            var newRequest = new Request()
            {
                Id = Guid.NewGuid(),
                Date = date,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };

            await _blogContext.Requests.AddAsync(newRequest);

            await _blogContext.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {            
            return await _blogContext.Requests
                .OrderByDescending(log => log.Date)
                .ToArrayAsync();
        }
    }
}
