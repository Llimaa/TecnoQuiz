using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Users
{
    public class GetUserByEmailQuery: IRequest<UserViewModel>
    {
        public string Email { get; set; }
    }
}
