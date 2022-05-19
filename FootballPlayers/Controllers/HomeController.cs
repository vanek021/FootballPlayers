using FootballPlayers.Hubs;
using FootballPlayers.Models;
using FootballPlayers.Services;
using FootballPlayers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FootballPlayers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PlayerService _playerService;
        private readonly IHubContext<PlayerHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, 
            PlayerService playerService, 
            IHubContext<PlayerHub> hubContext)
        {
            _logger = logger;
            _playerService = playerService;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            ViewBag.Teams = _playerService.GetPlayerTeams();

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddPlayer(AddPlayerViewModel addPlayerViewModel)
        {
            if (ModelState.IsValid)
            {
                var player = _playerService.AddPlayerToDatabase(addPlayerViewModel);
                await _hubContext.Clients.All.SendAsync("ReceivePlayerUpdate", player);
            }             
            else
                return RedirectToAction("Index", addPlayerViewModel);
            
            return RedirectToAction("Index","Players");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}