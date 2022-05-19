using FootballPlayers.Services;
using FootballPlayers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FootballPlayers.Controllers
{
    public class PlayersController : Controller
    {
        private readonly PlayerService _playerService;

        public PlayersController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        public IActionResult Index()
        {
            var players = _playerService.GetPlayers();

            return View(players);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Teams = _playerService.GetPlayerTeams();

            var player = _playerService.GetPlayerById(id);

            var viewModel = new EditPlayerViewModel()
            {
                Id = player.Id,
                Name = player.Name,
                Surname = player.Surname,
                Gender = player.Gender,
                BirthDate = player.BirthDate,
                Team = player.Team,
                Country = player.Country,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditPlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _playerService.ChangePlayerData(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
