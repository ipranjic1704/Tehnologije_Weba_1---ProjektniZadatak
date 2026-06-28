using DataAccessLayer.Model;
using DataAccessLayer.Repository.Interface;
using DataAccessLayer.Services.Interface;

namespace DataAccessLayer.Services.Implementation
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository repository;

        public MatchService(IMatchRepository repository)
        {
            this.repository = repository;
        }

        public List<Match> GetAll()
        {
            return repository.GetAll();
        }

        public Match? GetById(int id)
        {
            return repository.GetById(id);
        }

        public Match Create(Match match)
        {
            return repository.Create(match);
        }

        public Match? Update(int id, Match match)
        {
            var existing = repository.GetById(id);
            if (existing == null)
                return null;
            return repository.Update(id, match);
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
