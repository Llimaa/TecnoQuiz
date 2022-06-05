using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Users
{
    public class GetUserByIdQuery: IRequest<UserViewModel>
    {
        public Guid Id { get; set; }
    }
}
