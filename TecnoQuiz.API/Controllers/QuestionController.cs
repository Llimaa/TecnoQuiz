using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecnoQuiz.Application.Commands.Questions.Inputs;
using TecnoQuiz.Application.Queries.Questions;

namespace TecnoQuiz.API.Controllers
{
    [Authorize]
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetQuestionByIdQuery(id);
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpGet("quiz")]
        public async Task<IActionResult> GetByQuizId([FromQuery] Guid quizId)
        {
            var command = new GetQuestionByQuizIdQuery(quizId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("new")]
        public async Task<IActionResult> New([FromBody] CreateQuestionCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(New), id, command);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateQuestionCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new RemoveQuestionCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
