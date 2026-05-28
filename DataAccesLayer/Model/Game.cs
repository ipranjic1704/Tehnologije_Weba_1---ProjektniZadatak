namespace DataAccessLayer.Model
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        public ICollection<Tournament> Tournaments { get; set; } = new List<Tournament>();
    }
}
