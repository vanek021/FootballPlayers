namespace FootballPlayers.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }

    }
}
