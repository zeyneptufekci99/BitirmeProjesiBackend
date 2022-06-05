using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _meditor;

        public AuthController(IMediator meditor)
        {
            _meditor = meditor;
        }
        //api/Auth post
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] CheckUserQuery query)
        {
            var userDto = await _meditor.Send(query);

            if(userDto == null)
            {
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }

            TokenGenerator tokenGenerator = new TokenGenerator();
            var token = tokenGenerator.GenerateJwt(userDto);
            return Created("",token);
        }


        /// <summary>
        ///  DONT USE
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetUserInfo()
        {
           var name = User.Claims?.FirstOrDefault(x => x.Type == "Name")?.Value;
            return Ok(name);
        }
    }
}
