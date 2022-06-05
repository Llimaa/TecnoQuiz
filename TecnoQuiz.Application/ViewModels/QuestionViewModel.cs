
namespace TecnoQuiz.Application.ViewModels
{
    public class QuestionViewModel
    {
        public QuestionViewModel(string description)
        {
            Description = description;
        }

        public QuestionViewModel(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public QuestionViewModel(string description, List<AnswerViewModel> answers)
        {
            Description = description;
            Answers = answers;
        }


        public Guid Id { get; set; }
        public string Description { get; private set; }
        public List<AnswerViewModel> Answers { get; private set; }
    }
}
