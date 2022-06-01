using System;

namespace TecnoQuiz.Domain.Entities
{
    public class User: BaseEntity
    {
        public User()
        {
            
        }
        public User(string username, string role, DateTime birthday, string document)
        {
            Username = username;
            Role = role;
            Birthday = birthday;
            Document = document;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Document { get; private set; }
    }
}
