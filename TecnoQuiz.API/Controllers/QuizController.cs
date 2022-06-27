using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecnoQuiz.Application.Commands.Quizzes.Inputs;
using TecnoQuiz.Application.Queries.Quizzes;

namespace TecnoQuiz.API.Controllers
{
    [Authorize]
    [Route("api/quizzes")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllQuizQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdQuizQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("status")]
        public async Task<IActionResult> GetByStatus([FromQuery] EQuizStatus status)
        {
            var query = new GetByStatusQuizQuery(status);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetByUserId([FromQuery] Guid userId)
        {
            var query = new GetByUserIdQuizQuery(userId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("new")]
        public async Task<IActionResult> New([FromBody] CreateQuizCommand createQuiz)
        {
            var id = await _mediator.Send(createQuiz);
            return CreatedAtAction(nameof(New), id, createQuiz);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateQuizCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("active/{id}")]
        public async Task<IActionResult> Active(Guid id)
        {
            var command = new ActiveQuizCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("inaactive/{id}")]
        public async Task<IActionResult> Inactive(Guid id)
        {
            var command = new InactiveQuizCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new RemoveQuizCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
