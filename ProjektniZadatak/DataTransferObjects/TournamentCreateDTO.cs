namespace ProjektniZadatak.DataTransferObjects
{
    public class TournamentCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GameId { get; set; }
    }
}
