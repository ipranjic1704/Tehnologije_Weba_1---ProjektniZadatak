using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IMatchService
    {
        List<Match> GetAll();
        Match? GetById(int id);
        Match Create(Match match);
        Match? Update(int id, Match match);
        bool Delete(int id);
    }
}
