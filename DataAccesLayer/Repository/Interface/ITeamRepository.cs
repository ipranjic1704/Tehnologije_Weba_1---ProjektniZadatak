using DataAccessLayer.Model;

namespace DataAccessLayer.Repository.Interface
{
    public interface ITeamRepository
    {
        List<Team> GetAll();
        Team? GetById(int id);
        Team? GetWithPlayers(int id);
        List<Player> GetPlayersFromTeam(int id);
        Team Create(Team team);
        Team Update(int id, Team team);
        void Delete(int id);
    }
}
