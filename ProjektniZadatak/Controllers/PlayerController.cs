using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin,User")]
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
        [Authorize(Roles = "Admin,User")]
        public ActionResult<Player> GetById(int id)
        {
            var player = service.GetById(id);
            if (player == null)
                return NotFound();
            return Ok(player);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
                var result = service.Update(id, updatedPlayer);
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
        [Authorize(Roles = "Admin")]
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
