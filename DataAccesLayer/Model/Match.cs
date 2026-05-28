namespace DataAccessLayer.Model
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string Status { get; set; } = "Scheduled";

        public int TournamentId { get; set; }
        public Tournament? Tournament { get; set; }

        public int FirstTeamId { get; set; }
        public Team? FirstTeam { get; set; }

        public int SecondTeamId { get; set; }
        public Team? SecondTeam { get; set; }

        public MatchResult? MatchResult { get; set; }
    }
}