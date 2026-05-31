using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatak.DataTransferObjects;

namespace ProjektniZadatak.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService service;

        public PlayerController(IPlayerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Player>> GetAll()
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
        public ActionResult<Player> GetById(int id)
        {
            var player = service.GetById(id);
            if (player == null)
                return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public ActionResult<Player> Create([FromBody] PlayerCreateDTO dto)
        {
            try
            {
                var player = new Player()
                {
                    Nickname = dto.Nickname,
                    Role = dto.Role,
                    TeamId = dto.TeamId
                };
                var created = service.Create(player);
                return Created(Url.Action(nameof(GetById), new { id = created.Id }), created);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Player> Update(int id, [FromBody] PlayerCreateDTO dto)
        {
            try
            {
                var updatedPlayer = new Player()
                {
                    Nickname = dto.Nickname,
                    Role = dto.Role,
                    TeamId = dto.TeamId
                };
                return Ok(service.Update(id, updatedPlayer));
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
