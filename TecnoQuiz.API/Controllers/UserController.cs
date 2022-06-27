using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecnoQuiz.Application.Commands.Users.Inputs;
using TecnoQuiz.Application.Queries.Users;

namespace TecnoQuiz.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [Authorize]
        [HttpGet("/email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var query = new GetUserByEmailQuery(email);

            var user = _mediator.Send(query);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var loginUserViewModel =  await _mediator.Send(command);

            if (loginUserViewModel == null) return BadRequest();

            return Ok(loginUserViewModel);
        }

        [HttpPost("new")]
        public async Task<IActionResult> New([FromBody] CreateUserCommand command)
        {
            var idUser = await _mediator.Send(command);
            return CreatedAtAction(nameof(New), new { id = idUser }, command);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [Authorize]
        [HttpPatch("active/{id}")]
        public async Task<IActionResult> Active(ActiveUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [Authorize]
        [HttpPatch("inactive/{id}")]
        public async Task<IActionResult> Inactive(InactiveUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
