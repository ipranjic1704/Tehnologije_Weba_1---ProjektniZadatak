using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjektniZadatak.DataTransferObjects;

namespace ProjektniZadatak.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService service;

        public TeamController(ITeamService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Team>> GetAll()
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
        public ActionResult<Team> GetById(int id)
        {
            var team = service.GetWithPlayers(id);
            if (team == null)
                return NotFound();
            return Ok(team);
        }

        [HttpGet("{id}/players")]
        public ActionResult<List<Player>> GetPlayers(int id)
        {
            var team = service.GetById(id);
            if (team == null)
                return NotFound();
            return Ok(service.GetPlayersFromTeam(id));
        }

        [HttpPost]
        public ActionResult<Team> Create([FromBody] TeamCreateDTO dto)
        {
            try
            {
                var team = new Team()
                {
                    Name = dto.Name,
                    Tag = dto.Tag,
                    CreatedAt = dto.CreatedAt ?? DateTime.Now
                };
                var created = service.Create(team);
                return Created(Url.Action(nameof(GetById), new { id = created.Id }), created);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Team> Update(int id, [FromBody] TeamCreateDTO dto)
        {
            try
            {
                Team updatedTeam = new Team()
                {
                    Name = dto.Name,
                    Tag = dto.Tag
                };
                var result = service.Update(id, updatedTeam);
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
                if(!service.Delete(id))
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
