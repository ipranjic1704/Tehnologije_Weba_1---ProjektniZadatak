namespace DataAccessLayer.Model
{
    public class TournamentRegistration
    {
        public int Id { get; set; }
        public DateTime Registration { get; set; } = DateTime.Now;

        public int TournamentId { get; set; }
        public Tournament? Tournament { get; set; }

        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}