namespace TecnoQuiz.Application.ViewModels
{
    public class QuizViewModel
    {
        public QuizViewModel(string title, string description, EQuizStatus status, UserViewModel user, List<QuestionViewModel> questions)
        {
            Title = title;
            Description = description;
            Status = status;
            User = user;
            Questions = questions;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public EQuizStatus Status { get; set; }
        public UserViewModel  User { get; private set; }
        public List<QuestionViewModel> Questions { get; private set; }
    }
}
