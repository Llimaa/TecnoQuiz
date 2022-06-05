using MediatR;
using TecnoQuiz.Application.ViewModels;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.Quizzes
{
    public class GetByStatusQuizQueryHandler : IRequestHandler<GetByStatusQuizQuery, IList<QuizViewModel>>
    {
        private readonly IQuizRepository _quizRepository;

        public GetByStatusQuizQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<IList<QuizViewModel>> Handle(GetByStatusQuizQuery request, CancellationToken cancellationToken)
        {
            var quizzes = await _quizRepository.GetByStatusAsync(request.status);

            if (quizzes == null) return null;

            var quizzesViewModel = quizzes.Select(quiz =>
            new QuizViewModel(
                quiz.Title,
                quiz.Description,
                quiz.Status,
                new UserViewModel(quiz.User.Id, quiz.User.FullName, quiz.User.Email, quiz.User.Role, quiz.User.Birthday, quiz.User.Document, quiz.User.Active),
                quiz.Questions.Select(question => new QuestionViewModel(question.Description)).ToList()));

            return quizzesViewModel.ToList();
        }
    }
}
