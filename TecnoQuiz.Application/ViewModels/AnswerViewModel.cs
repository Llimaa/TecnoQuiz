namespace TecnoQuiz.Application.ViewModels
{
    public class AnswerViewModel
    {
        public AnswerViewModel(string description, bool isRight)
        {
            Description = description;
            IsRight = isRight;
        }

        public AnswerViewModel(Guid id, string description, bool isRight)
        {
            Id = id;
            Description = description;
            IsRight = isRight;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRight { get; set; }
    }
}
