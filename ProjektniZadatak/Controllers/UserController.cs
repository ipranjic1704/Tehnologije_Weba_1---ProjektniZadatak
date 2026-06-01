using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatak.DataTransferObjects;
using ProjektniZadatak.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer.Model;

namespace ProjektniZadatak.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly IConfiguration configuration;

        public UserController(IUserService service, IConfiguration configuration)
        {
            this.service = service;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDTO dto)
        {
            try
            {
                var user = service.Register(dto.Username, dto.Password);
                if (user == null)
                {
                    return BadRequest($"Korisnicko ime {dto.Username} već postoji.");
                }
                return Ok(new { user.Id, user.Username, user.Role});
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult Login(UserLoginDTO dto)
        {
            try
            {
                var user = service.Login(dto.Username, dto.Password);
                if (user == null)
                    return BadRequest("Neispravno korisnicko ime ili lozinka");

                var secureKey = configuration["JWT:SecureKey"];
                var token = JwtTokenProvider.CreateToken(secureKey!, 120, user.Username, user.Role);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("promote/{username}")]
        public ActionResult Promote(string username)
        {
            try
            {
                User? user = service.PromoteToAdmin(username);
                if (user == null)
                    return NotFound($"Korisnik {username} ne postoji.");

                return Ok(new { user.Id, user.Username, user.Role});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
