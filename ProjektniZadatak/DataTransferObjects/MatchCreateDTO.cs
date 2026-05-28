namespace ProjektniZadatak.DataTransferObjects
{
    public class MatchCreateDTO
    {
        public DateTime ScheduledAt { get; set; }
        public int TournamentId { get; set; }
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }
    }
}
