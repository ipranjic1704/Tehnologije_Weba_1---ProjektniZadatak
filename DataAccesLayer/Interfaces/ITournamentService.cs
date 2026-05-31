using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ITournamentService
    {
        List<Tournament> GetAll();
        Tournament? GetById(int id);
        Tournament? GetWithMatches(int id);
        Tournament Create(Tournament tournament);
        Tournament? Update(int id, Tournament tournament);
        bool Delete(int id);
    }
}
