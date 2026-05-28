using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    internal interface ITeamRepository
    {
        List<Team> GetAllTeams();
        Team? GetById(int id);
        Team? GetWithPlayers(int id);
        List<Player> GetPlayersFromTeam(int id);
        Team Add(Team team);
        Team Update(int id, Team team);
        void Delete(int id);
    }
}
