using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TecnoQuiz.Application.Commands.Answers.Inputs;
using TecnoQuiz.Application.Queries.Answers;
using TecnoQuiz.Application.Queries.UserAnswers;

namespace TecnoQuiz.API.Controllers
{
    [Authorize]
    [Route("api/answers")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetAnswerByIdQuery(id);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("question")]
        public async Task<IActionResult> GetByQuestionId([FromQuery] Guid questionId)
        {
            var command = new GetAnswerByQuestionIdQuery(questionId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("itHasMoreThenFive/{questionId}")]
        public async Task<IActionResult> ItHasFiveAnswersToQuestionQuery(Guid questionId)
        {
            var command = new ItHasFiveAnswersToQuestionQuery(questionId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("totalHight")]
        public async Task<IActionResult> GetTotalRight([FromQuery] GetTotalRightQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("totalWrong")]
        public async Task<IActionResult> GetTotalWrong([FromQuery] GetTotalWrongQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAnswerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

         [HttpPatch]
        public async Task<IActionResult> Update(UpdateAnswerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveAnswerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
