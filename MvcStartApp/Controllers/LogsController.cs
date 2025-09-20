using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;
using MvcStartApp.Repositories;
using System.Diagnostics;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetRequests();
            return View(logs);
        }
    }
}
