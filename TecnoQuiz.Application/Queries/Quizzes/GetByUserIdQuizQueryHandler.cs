using MediatR;
using TecnoQuiz.Application.ViewModels;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.Quizzes
{
    public class GetByUserIdQuizQueryHandler : IRequestHandler<GetByUserIdQuizQuery, IList<QuizViewModel>>
    {
        private readonly IQuizRepository _quizRepository;
        public GetByUserIdQuizQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<IList<QuizViewModel>> Handle(GetByUserIdQuizQuery request, CancellationToken cancellationToken)
        {
            var quizzes = await _quizRepository.GetByUserIdAsync(request.UserId);

            if (quizzes == null) return null;

            var quizzesViewModel = quizzes.Select(quiz =>
            new QuizViewModel(
                quiz.Id,
                quiz.Title,
                quiz.Description,
                quiz.Status,
                new UserViewModel(quiz.User.Id, quiz.User.FullName, quiz.User.Email, quiz.User.Role, quiz.User.Birthday, quiz.User.Document, quiz.User.Active),
                quiz.Questions.Select(question => new QuestionViewModel(
                    question.Id,
                    question.Description,
                    question.Answers.Select(answer => new AnswerViewModel(answer.Id, answer.Description, answer.IsRight)).ToList()
                    )).ToList())
                );

            return quizzesViewModel.ToList();
        }
    }
}
