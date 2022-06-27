namespace TecnoQuiz.Application.ViewModels
{
    public class QuizViewModel
    {
        public QuizViewModel(Guid id, string title, string description, EQuizStatus status, UserViewModel user, List<QuestionViewModel> questions)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            User = user;
            Questions = questions;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EQuizStatus Status { get; set; }
        public UserViewModel User { get; private set; }
        public List<QuestionViewModel>? Questions { get; private set; }
    }
}
