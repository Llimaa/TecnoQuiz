
namespace TecnoQuiz.Domain.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, List<string> roles);
        string ComputeSha256Hash(string password);
    }
}
