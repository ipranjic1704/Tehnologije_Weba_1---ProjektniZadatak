using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly EsportManagerContext context;
        public TournamentRepository(EsportManagerContext context)
        {
            this.context = context;
        }

        public List<Tournament> GetAll()
        {
            return context.Tournaments.ToList();
        }

        public Tournament? GetById(int id)
        {
            return context.Tournaments.FirstOrDefault(t => t.Id == id);
        }

        public Tournament? GetWithMatches(int id)
        {
            return context.Tournaments
                .Include(t => t.Matches)
                .FirstOrDefault(t => t.Id == id);
        }

        public Tournament Create(Tournament tournament)
        {
            context.Tournaments.Add(tournament);
            context.SaveChanges();
            return tournament;
        }

        public Tournament Update(int id, Tournament updatedTournament)
        {
            var tournament = context.Tournaments.FirstOrDefault(t => t.Id == id)!;
            tournament.Name = updatedTournament.Name;
            tournament.StartDate = updatedTournament.StartDate;
            tournament.EndDate = updatedTournament.EndDate;
            tournament.Status = updatedTournament.Status;
            context.SaveChanges();
            return tournament;
        }

        public void Delete(int id)
        {
            var tournament = context.Tournaments.FirstOrDefault(t => t.Id == id)!;
            context.Tournaments.Remove(tournament);
            context.SaveChanges();
        }
    }
}
