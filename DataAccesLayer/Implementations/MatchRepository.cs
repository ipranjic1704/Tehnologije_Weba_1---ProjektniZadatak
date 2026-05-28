using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Implementations
{
    public class MatchRepository : IMatchRepository
    {
        private readonly EsportManagerContext context;

        public MatchRepository(EsportManagerContext context)
        {
            this.context = context;
        }

        public List<Match> GetAllMatches()
        {
            return context.Matches.ToList();
        }

        public Match? GetById(int id)
        {
            return context.Matches
                .Include(m => m.MatchResult)
                .FirstOrDefault(m => m.Id == id);
        }

        public Match Add(Match match)
        {
            context.Matches.Add(match);
            context.SaveChanges();
            return match;
        }

        public Match Update(int id, Match updatedMatch)
        {
            var match = context.Matches.FirstOrDefault(m => m.Id == id)!;
            match.ScheduledAt = updatedMatch.ScheduledAt;
            match.Status = updatedMatch.Status;
            context.SaveChanges();
            return match;
        }

        public void Delete(int id)
        {
            var match = context.Matches.FirstOrDefault(m => m.Id == id)!;
            context.Matches.Remove(match);
            context.SaveChanges();
        }
    }
}
