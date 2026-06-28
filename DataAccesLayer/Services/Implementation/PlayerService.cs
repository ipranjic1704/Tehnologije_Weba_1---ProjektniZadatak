using DataAccessLayer.Model;
using DataAccessLayer.Repository.Interface;
using DataAccessLayer.Services.Interface;

namespace DataAccessLayer.Services.Implementation
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository repository;

        public PlayerService(IPlayerRepository repository)
        {
            this.repository = repository;
        }

        public List<Player> GetAll() => repository.GetAll();

        public Player? GetById(int id) => repository.GetById(id);

        public Player Create(Player player) => repository.Create(player);

        public Player? Update(int id, Player player)
        {
            var existing = repository.GetById(id);
            if (existing == null)
                return null;
            return repository.Update(id, player);
        }

        public bool Delete(int id)
        {
            var existing = repository.GetById(id);
            if (existing == null)
                return false;
            repository.Delete(id);
            return true;
        }
    }
}
