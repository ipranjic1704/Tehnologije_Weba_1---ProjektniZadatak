using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatak.DataTransferObjects;

namespace ProjektniZadatak.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepository repository;

        public MatchController(IMatchRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Match>> GetAll()
        {
            try
            {
                return Ok(repository.GetAllMatches());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Match> GetById(int id)
        {
            var match = repository.GetById(id);
            if (match == null)
                return NotFound();
            return Ok(match);
        }

        [HttpPost]
        public ActionResult<Match> Create([FromBody] MatchCreateDTO dto)
        {
            try
            {
                var match = new Match()
                {
                    ScheduledAt = dto.ScheduledAt,
                    TournamentId = dto.TournamentId,
                    FirstTeamId = dto.FirstTeamId,
                    SecondTeamId = dto.SecondTeamId
                };
                var created = repository.Add(match);
                return Created(Url.Action(nameof(GetById), new { id = created.Id }), created);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Match> Update(int id, [FromBody] MatchCreateDTO dto)
        {
            try
            {
                var match = repository.GetById(id);
                if (match == null)
                    return NotFound();
                var updatedMatch = new Match()
                {
                    ScheduledAt = dto.ScheduledAt,
                    TournamentId = dto.TournamentId,
                    FirstTeamId = dto.FirstTeamId,
                    SecondTeamId = dto.SecondTeamId
                };
                return Ok(repository.Update(id, updatedMatch));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var match = repository.GetById(id);
                if (match == null)
                    return NotFound();
                repository.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}