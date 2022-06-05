namespace TecnoQuiz.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {

        }

        public User(string fullName, string email, string password, string role, DateTime birthday, string document)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
            Birthday = birthday;
            Document = document;
            Active = true;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Document { get; private set; }
        public bool Active { get; private set; }

        public void Update(string fullname, string email, DateTime birthday, string document)
        {
            FullName = fullname;
            Email = email;
            Birthday = birthday;
            Document = document;
        }

        public void ActiveUser()
        {
            Active = true;
        }
        public void DesactiveUser()
        {
            Active = false;
        }
    }
}
