using MediatR;
using TecnoQuiz.Application.ViewModels;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.Answers
{
    public class GetAnswerByQuestionIdQueryHandler : IRequestHandler<GetAnswerByQuestionIdQuery, IList<AnswerViewModel>>
    {
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerByQuestionIdQueryHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<IList<AnswerViewModel>> Handle(GetAnswerByQuestionIdQuery request, CancellationToken cancellationToken)
        {
            var answers = await _answerRepository.GetByQuestionIdAsync(request.QuestionId);

            if (answers == null) return null;

            var answerViewModel = answers.Select(answer => new AnswerViewModel(answer.Id, answer.Description, answer.IsRight)).ToList();
            return answerViewModel;
        }
    }
}
