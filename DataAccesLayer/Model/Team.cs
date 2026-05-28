namespace DataAccessLayer.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Tag { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
        public ICollection<TournamentRegistration> TournamentRegistrations { get; set; } = new List<TournamentRegistration>();

    }
}
