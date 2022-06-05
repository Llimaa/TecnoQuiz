namespace TecnoQuiz.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(Guid id, string fullName, string email, string role, DateTime birthday, string document, bool active)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Role = role;
            Birthday = birthday;
            Document = document;
            Active = active;
        }

        public Guid Id { get; private set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime Birthday { get; set; }
        public string Document { get; set; }
        public bool Active { get; set; }
    }
}
