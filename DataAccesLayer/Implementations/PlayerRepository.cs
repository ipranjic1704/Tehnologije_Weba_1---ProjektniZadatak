using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
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

        public List<Player> GetAllPlayers()
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
