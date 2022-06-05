using MediatR;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.UserAnswers
{
    public class GetTotalRightQueryHandler : IRequestHandler<GetTotalRightQuery, int>
    {
        private readonly IUserAnswerRepository _userAnswerRepository;

        public GetTotalRightQueryHandler(IUserAnswerRepository userAnswerRepository)
        {
            _userAnswerRepository = userAnswerRepository;
        }

        public async Task<int> Handle(GetTotalRightQuery request, CancellationToken cancellationToken)
        {
            var totalRight = await _userAnswerRepository.GetTotalRight(request.UserId, request.QuizId);
            return totalRight == null ? 0 : totalRight;
        }
    }
}
