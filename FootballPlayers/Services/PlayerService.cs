using FootballPlayers.Models;
using FootballPlayers.ViewModels;

namespace FootballPlayers.Services
{
    public class PlayerService
    {
        private readonly ApplicationContext _db;
        public PlayerService(ApplicationContext context)
        {
            _db = context;
        }

        public Player AddPlayerToDatabase(AddPlayerViewModel model)
        {
            var player = new Player()
            {
                Name = model.Name,
                Surname = model.Surname,
                Gender = model.Gender,
                BirthDate = model.BirthDate,
                Team = model.Team,
                Country = model.Country
            };

            _db.Add(player);
            _db.SaveChanges();

            return player;
        }

        public void ChangePlayerData(EditPlayerViewModel model)
        {
            var player = _db.Players.Where(x => x.Id == model.Id).FirstOrDefault();
            if (player != null)
            {
                player.Name = model.Name;
                player.Surname = model.Surname;
                player.Gender = model.Gender;
                player.BirthDate = model.BirthDate;
                player.Team = model.Team;
                player.Country = model.Country;
            }

            _db.SaveChanges();
        }

        public List<string> GetPlayerTeams()
        {
            return _db.Players.Select(p => p.Team).Distinct().ToList();
        }

        public List<Player> GetPlayers()
        {
            return _db.Players.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _db.Players.Where(x => x.Id == id).First();
        }
    }
}
