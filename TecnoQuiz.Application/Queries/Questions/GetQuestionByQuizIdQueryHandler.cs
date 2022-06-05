using MediatR;
using TecnoQuiz.Application.ViewModels;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.Questions
{
    public class GetQuestionByQuizIdQueryHandler : IRequestHandler<GetQuestionByQuizIdQuery, IList<QuestionViewModel>>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionByQuizIdQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<IList<QuestionViewModel>> Handle(GetQuestionByQuizIdQuery request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetByQuizIdAsync(request.QuizId);
            if (questions == null) return null;

            var questionsViewModels = questions.Select(question => new QuestionViewModel(question.Id, question.Description)).ToList();
            return questionsViewModels;
        }
    }
}
