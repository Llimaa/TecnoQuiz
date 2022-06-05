using MediatR;
using TecnoQuiz.Application.ViewModels;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.Quizzes
{
    public class GetByIdQuizQueryHandler : IRequestHandler<GetByIdQuizQuery, QuizViewModel>
    {
        private readonly IQuizRepository _quizRepository;
        public GetByIdQuizQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<QuizViewModel> Handle(GetByIdQuizQuery request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetByIdAsync(request.Id);

            if (quiz == null) return null;

            var quizViewModel =
            new QuizViewModel(
                quiz.Title,
                quiz.Description,
                quiz.Status,
                new UserViewModel(quiz.User.Id, quiz.User.FullName, quiz.User.Email, quiz.User.Role, quiz.User.Birthday, quiz.User.Document, quiz.User.Active),
                quiz.Questions.Select(question => new QuestionViewModel(question.Description)).ToList());

            return quizViewModel;
        }
    }
}
