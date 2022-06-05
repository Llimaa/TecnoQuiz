using MediatR;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.UserAnswers
{
    public class GetTotalWrongQueryHandler : IRequestHandler<GetTotalRightQuery, int>
    {
        private readonly IUserAnswerRepository _userAnswerRepository;

        public GetTotalWrongQueryHandler(IUserAnswerRepository userAnswerRepository)
        {
            _userAnswerRepository = userAnswerRepository;
        }

        public async Task<int> Handle(GetTotalRightQuery request, CancellationToken cancellationToken)
        {
            var totalRight = await _userAnswerRepository.GetTotalWrong(request.UserId, request.QuizId);
            return totalRight == null ? 0 : totalRight;
        }
    }
}
