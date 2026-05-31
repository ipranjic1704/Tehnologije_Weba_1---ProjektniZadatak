using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ITeamService
    {
        List<Team> GetAll();
        Team? GetById(int id);
        Team? GetWithPlayers(int id);
        List<Player> GetPlayersFromTeam(int id);
        Team Create(Team team);
        Team? Update(int id, Team team);
        bool Delete(int id);
    }
}
