namespace ProjektniZadatak.DataTransferObjects
{
    public class TeamCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
    }
}
