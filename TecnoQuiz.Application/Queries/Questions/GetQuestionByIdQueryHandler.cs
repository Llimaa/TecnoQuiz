using MediatR;
using TecnoQuiz.Application.ViewModels;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.Questions
{
    public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, QuestionViewModel>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionByIdQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionViewModel> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var question = await _questionRepository.GetByIdAsync(request.Id);

            if (question == null) return null;

            var questionViewModel = new QuestionViewModel(question.Id, question.Description);
            return questionViewModel;
        }
    }
}
