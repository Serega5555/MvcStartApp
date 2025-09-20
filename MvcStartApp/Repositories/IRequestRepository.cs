using MvcStartApp.Models.Db;

namespace MvcStartApp.Repositories
{
    public interface IRequestRepository
    {
        Task AddRequest(DateTime date, HttpContext context);
        Task<Request[]> GetRequests();
    }
}
