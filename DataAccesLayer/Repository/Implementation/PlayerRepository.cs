using DataAccessLayer.Model;
using DataAccessLayer.Repository.Interface;

namespace DataAccessLayer.Repository.Implementation
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly EsportManagerContext context;

        public PlayerRepository(EsportManagerContext context)
        {
            this.context = context;
        }

        public Player Create(Player player)
        {
            context.Players.Add(player);
            context.SaveChanges();
            return player;
        }

        public void Delete(int id)
        {
            Player? player = context.Players.FirstOrDefault(p => p.Id == id)!;
            context.Players.Remove(player);
            context.SaveChanges();
        }

        public List<Player> GetAll()
        {
            return context.Players.ToList();
        }

        public Player? GetById(int id)
        {
            return context.Players.FirstOrDefault(p =>  id == p.Id);
        }

        public Player Update(int id, Player player)
        {
            Player? updatedPlayer = context.Players.FirstOrDefault(p => p.Id == id)!;
            updatedPlayer.Nickname = player.Nickname;
            updatedPlayer.Role = player.Role;
            context.SaveChanges();
            return updatedPlayer;
        }
    }
}
