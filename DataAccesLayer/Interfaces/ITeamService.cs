using DataAccessLayer.Model;

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
