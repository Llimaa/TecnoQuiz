namespace TecnoQuiz.Application.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel(string fullName, string email, string token)
        {
            FullName = fullName;
            Email = email;
            Token = token;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
