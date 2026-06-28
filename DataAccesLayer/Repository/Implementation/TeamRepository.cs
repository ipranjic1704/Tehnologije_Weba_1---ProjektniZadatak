using DataAccessLayer.Model;
using DataAccessLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository.Implementation
{
    public class TeamRepository : ITeamRepository
    {
        private readonly EsportManagerContext context;

        public TeamRepository(EsportManagerContext context)
        {
            this.context = context;
        }

        public List<Team> GetAll()
        {
            return context.Teams.ToList();
        }

        public Team? GetById(int id)
        {
            return context.Teams.FirstOrDefault(t => t.Id == id);
        }

        public Team? GetWithPlayers(int id)
        {
            return context.Teams
                .Include(t => t.Players)
                .FirstOrDefault(t => t.Id == id);
        }

        public List<Player> GetPlayersFromTeam(int id)
        {
            return context.Players
                .Where(p => p.TeamId == id)
                .ToList();
        }

        public Team Create(Team team)
        {
            context.Teams.Add(team);
            context.SaveChanges();
            return team;
        }

        public Team Update(int id, Team updatedTeam)
        {
            var team = context.Teams.FirstOrDefault(t => t.Id == id)!;
            team.Name = updatedTeam.Name;
            team.Tag = updatedTeam.Tag;
            context.SaveChanges();
            return team;
        }

        public void Delete(int id)
        {
            var team = context.Teams.FirstOrDefault(t => t.Id == id)!;
            context.Teams.Remove(team);
            context.SaveChanges();
        }
    }
}