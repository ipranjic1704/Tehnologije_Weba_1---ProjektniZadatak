using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IGameService
    {
        List<Game> GetAllGames();
        Game? GetById(int id);
        Game Create(Game game);
        Game? Update(int  id, Game game);
        bool Delete(int id);
    }
}
