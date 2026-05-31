using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository repository;

        public TeamService(ITeamRepository repository)
        {
            this.repository = repository;
        }

        public List<Team> GetAll() => repository.GetAll();

        public Team? GetById(int id) => repository.GetById(id);

        public Team? GetWithPlayers(int id) => repository.GetWithPlayers(id);

        public List<Player> GetPlayersFromTeam(int id) => repository.GetPlayersFromTeam(id);

        public Team Create(Team team) => repository.Create(team);

        public Team? Update(int id, Team team)
        {
            var existing = repository.GetById(id);
            if (existing == null)
                return null;
            return repository.Update(id, team);
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
