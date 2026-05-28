using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatak.DataTransferObjects;

namespace ProjektniZadatak.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository repository;

        public TeamController(ITeamRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Team>> GetAll()
        {
            try
            {
                return Ok(repository.GetAllTeams());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Team> GetById(int id)
        {
            var team = repository.GetWithPlayers(id);
            if (team == null)
                return NotFound();
            return Ok(team);
        }

        [HttpGet("{id}/players")]
        public ActionResult<List<Player>> GetPlayers(int id)
        {
            var team = repository.GetById(id);
            if (team == null)
                return NotFound();
            return Ok(repository.GetPlayersFromTeam(id));
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
                var created = repository.Add(team);
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
                var team = repository.GetById(id);
                if (team == null)
                    return NotFound();
                var updatedTeam = new Team()
                {
                    Name = dto.Name,
                    Tag = dto.Tag
                };
                return Ok(repository.Update(id, updatedTeam));
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
                var team = repository.GetById(id);
                if (team == null)
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
