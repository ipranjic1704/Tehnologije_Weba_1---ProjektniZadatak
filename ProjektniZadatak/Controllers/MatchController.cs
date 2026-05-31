using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatak.DataTransferObjects;

namespace ProjektniZadatak.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService service;

        public MatchController(IMatchService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Match>> GetAll()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Match> GetById(int id)
        {
            var match = service.GetById(id);
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
                var created = service.Create(match);
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
                var updatedMatch = new Match()
                {
                    ScheduledAt = dto.ScheduledAt,
                    TournamentId = dto.TournamentId,
                    FirstTeamId = dto.FirstTeamId,
                    SecondTeamId = dto.SecondTeamId
                };
                var result = service.Update(id, updatedMatch);
                if (result == null)
                    return NotFound();
                return Ok(result);
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
                if (!service.Delete(id))
                    return NotFound();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}