using MediatR;
using TecnoQuiz.Application.ViewModels;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.Answers
{
    public class GetAnswerByIdQueryHandler : IRequestHandler<GetAnswerByIdQuery, AnswerViewModel>
    {
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerByIdQueryHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<AnswerViewModel> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
        {
            var answer = await _answerRepository.GetByIdAsync(request.Id);

            if (answer == null) return null;

            return new AnswerViewModel(answer.Id, answer.Description, answer.IsRight);
        }
    }
}
