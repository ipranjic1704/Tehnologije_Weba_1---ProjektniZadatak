using DataAccessLayer.Model;
using DataAccessLayer.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatak.DataTransferObjects;

namespace ProjektniZadatak.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService service;

        public GameController(IGameService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Game>> GetAll()
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
        [Authorize(Roles = "Admin,User")]
        public ActionResult<Game> GetById(int id)
        {
            Game? game = service.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<Game> Create([FromBody] GameCreateDTO gameDTO)
        {
            try
            {
                Game? game = new Game()
                {
                    Name = gameDTO.Name,
                    Genre = gameDTO.Genre
                };
                var createdGame = service.Create(game);
                return Created(Url.Action(nameof(GetById), new { id = createdGame.Id }), createdGame);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Game> Update(int id, [FromBody] GameCreateDTO gameDTO)
        {
            try
            {
                Game game = new Game()
                {
                    Name = gameDTO.Name,
                    Genre = gameDTO.Genre
                };
                Game? updated = service.Update(id, game);
                if (updated == null)
                    return NotFound();
                return Ok(updated);
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
            if (!service.Delete(id))
                return NotFound();
            return NoContent();
        }
    }
}
