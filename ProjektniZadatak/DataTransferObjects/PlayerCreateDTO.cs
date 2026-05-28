namespace ProjektniZadatak.DataTransferObjects
{
    public class PlayerCreateDTO
    {
        public string Nickname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int TeamId { get; set; }
    }
}
