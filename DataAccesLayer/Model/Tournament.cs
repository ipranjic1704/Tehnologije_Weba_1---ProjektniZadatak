namespace DataAccessLayer.Model
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Upcoming";

        public int GameId { get; set; }
        public Game? Game { get; set; }

        public ICollection<Match> Matches { get; set; } = new List<Match>();
        public ICollection<TournamentRegistration> TournamentRegistrations { get; set; } = new List<TournamentRegistration>();
    }
}