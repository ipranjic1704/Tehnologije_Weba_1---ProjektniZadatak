using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatak.DataTransferObjects;

namespace ProjektniZadatak.Controllers
{
    [Route("api/tournaments")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService service;

        public TournamentController(ITournamentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Tournament>> GetAll()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Tournament> GetById([FromRoute] int id)
        {
            Tournament? tournament = service.GetById(id);
            if(tournament == null)
                return NotFound();
            return Ok(tournament);
        }

        [HttpGet("{id}/matches")]
        public ActionResult<Tournament> GetWithMatches(int id)
        {
            Tournament? withMatches = service.GetWithMatches(id);
            if (withMatches == null)
                return NotFound();
            return Ok(withMatches);
        }

        [HttpPost]
        public ActionResult<Tournament> Create([FromBody] TournamentCreateDTO dto)
        {
            try
            {
                Tournament tournament = new Tournament()
                {
                    Name = dto.Name,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    GameId = dto.GameId
                };
                Tournament createdTournament = service.Create(tournament);
                return Created(Url.Action(nameof(GetById), new {id = createdTournament.Id}), createdTournament);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Tournament> Update(int id, [FromBody] TournamentCreateDTO dto)
        {
            try
            {
                Tournament tournament = new Tournament()
                {
                    Name = dto.Name,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    GameId = dto.GameId
                };
                Tournament? updatedTournament = service.Update(id, tournament);
                if(updatedTournament == null)
                    return NotFound();
                return Ok(updatedTournament);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!service.Delete(id))
                return NotFound();
            return NoContent();
        }
    }
}
