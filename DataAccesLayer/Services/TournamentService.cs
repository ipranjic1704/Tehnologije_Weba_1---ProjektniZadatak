using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository repository;

        public TournamentService(ITournamentRepository repository)
        {
            this.repository = repository;
        }

        public List<Tournament> GetAll() => repository.GetAll();

        public Tournament? GetById(int id) => repository.GetById(id);

        public Tournament? GetWithMatches(int id) => repository.GetWithMatches(id);

        public Tournament Create(Tournament tournament) => repository.Create(tournament);

        public Tournament? Update(int id, Tournament tournament)
        {
            var existing = repository.GetById(id);
            if (existing == null)
                return null;
            return repository.Update(id, tournament);
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
