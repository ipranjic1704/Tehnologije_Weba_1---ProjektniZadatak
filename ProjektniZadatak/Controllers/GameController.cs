using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatak.DataTransferObjects;

namespace ProjektniZadatak.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository repository;

        public GameController(IGameRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Game>> GetAllGames()
        {
            try
            {
                return Ok(repository.GetAllGames());
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            Game? game = repository.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public ActionResult<Game> Create([FromBody] GameCreateDTO gameDTO)
        {
            try
            {
                Game? game = new Game()
                {
                    Name = gameDTO.Name,
                    Genre = gameDTO.Genre
                };
                var createdGame = repository.Add(game);
                return Created(Url.Action(nameof(GetById), new { id = createdGame.Id }), createdGame);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Game> Update(int id, [FromBody] Game updatedGame)
        {
            try
            {
                Game? game = repository.GetById(id);

                if (game == null)
                    return NotFound();

                Game updated = repository.Update(id, updatedGame);
                return Ok(updated);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Game? game = repository.GetById(id);
            if (game == null)
                return NotFound();

            repository.Delete(id);
            return NoContent();
        }
    }
}
