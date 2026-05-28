using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatak.DataTransferObjects;

namespace ProjektniZadatak.Controllers
{
    [Route("api/tournaments")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentRepository repository;

        public TournamentController(ITournamentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Tournament>> GetAll()
        {
            try
            {
                return Ok(repository.GetAllTournaments());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Tournament> GetById(int id)
        {
            var tournament = repository.GetById(id);
            if (tournament == null)
                return NotFound();
            return Ok(tournament);
        }

        [HttpGet("{id}/matches")]
        public ActionResult<Tournament> GetWithMatches(int id)
        {
            var tournament = repository.GetWithMatches(id);
            if (tournament == null)
                return NotFound();
            return Ok(tournament);
        }

        [HttpPost]
        public ActionResult<Tournament> Create([FromBody] TournamentCreateDTO dto)
        {
            try
            {
                var tournament = new Tournament()
                {
                    Name = dto.Name,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    GameId = dto.GameId
                };
                var created = repository.Add(tournament);
                return Created(Url.Action(nameof(GetById), new { id = created.Id }), created);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Tournament> Update(int id, [FromBody] TournamentCreateDTO dto)
        {
            try
            {
                var tournament = repository.GetById(id);
                if (tournament == null)
                    return NotFound();
                var updatedTournament = new Tournament()
                {
                    Name = dto.Name,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    GameId = dto.GameId
                };
                return Ok(repository.Update(id, updatedTournament));
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
                var tournament = repository.GetById(id);
                if (tournament == null)
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
