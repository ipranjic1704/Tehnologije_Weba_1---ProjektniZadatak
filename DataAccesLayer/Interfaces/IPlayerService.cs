using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IPlayerService
    {
        List<Player> GetAll();
        Player? GetById(int id);
        Player Create(Player player);
        Player? Update(int id, Player player);
        bool Delete(int id);
    }
}
