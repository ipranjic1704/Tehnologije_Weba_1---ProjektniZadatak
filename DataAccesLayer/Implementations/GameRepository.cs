using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataAccessLayer.Implementations
{
    public class GameRepository : IGameRepository
    {
        private readonly EsportManagerContext context;

        public GameRepository(EsportManagerContext context)
        {
            this.context = context;
        }

        public Game Add(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
            return game;
        }

        public void Delete(int id)
        {
            Game? game = context.Games.FirstOrDefault(g => g.Id == id)!;
            context.Games.Remove(game);
            context.SaveChanges();
        }

        public List<Game> GetAllGames()
        {
            return context.Games.ToList();
        }

        public Game? GetById(int id)
        {
            return context.Games.FirstOrDefault(g => g.Id == id);
        }

        public Game Update(int id, Game game)
        {
            Game? updatedGame = context.Games.FirstOrDefault(g => g.Id == id)!;
            updatedGame.Name = game.Name;
            updatedGame.Genre = game.Genre;
            context.SaveChanges();
            return updatedGame;
        }
    }
}
