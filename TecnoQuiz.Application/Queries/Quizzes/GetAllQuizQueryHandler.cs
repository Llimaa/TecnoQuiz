using MediatR;
using TecnoQuiz.Application.ViewModels;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.Quizzes
{
    public class GetAllQuizQueryHandler : IRequestHandler<GetAllQuizQuery, IList<QuizViewModel>>
    {
        private readonly IQuizRepository _quizRepository;

        public GetAllQuizQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<IList<QuizViewModel>> Handle(GetAllQuizQuery request, CancellationToken cancellationToken)
        {
            var quizzes = await _quizRepository.GetAllAsync();

            if (quizzes == null) return null;

            var quizzesViewModel = quizzes.Select(quiz =>
            new QuizViewModel(
                quiz.Id,
                quiz.Title,
                quiz.Description,
                quiz.Status,
                new UserViewModel(quiz.User.Id, quiz.User.FullName, quiz.User.Email, quiz.User.Role, quiz.User.Birthday, quiz.User.Document, quiz.User.Active),
                quiz.Questions != null ? quiz.Questions.Select(question => new QuestionViewModel(question.Id, question.Description)).ToList() : new List<QuestionViewModel>()));

            return quizzesViewModel.ToList();
        }
    }
}
