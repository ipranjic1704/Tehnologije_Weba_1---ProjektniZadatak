namespace ProjektniZadatak.Model
{
    public class MatchResult
    {
        public int Id { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }

        public int MatchId { get; set; }
        public Match? Match { get; set; }
    }
}