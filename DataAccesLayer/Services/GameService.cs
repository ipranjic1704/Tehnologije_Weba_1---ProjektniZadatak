using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public Game Create(Game game)
        {
            return gameRepository.Create(game);
        }

        public bool Delete(int id)
        {
            Game? exists = gameRepository.GetById(id);
            if (exists == null)
            {
                return false;
            }
            gameRepository.Delete(id);
            return true;
        }

        public List<Game> GetAllGames()
        {
            return gameRepository.GetAllGames();
        }

        public Game? GetById(int id)
        {
            return gameRepository.GetById(id);
        }

        public Game? Update(int id, Game game)
        {
            Game? exists = gameRepository.GetById(id);
            if (exists == null)
            {
                Console.WriteLine("Pogreška ID... Ne postoji igra s tim ID");
                return null;
            }

            return gameRepository.Update(id, game);
        }
    }
}
