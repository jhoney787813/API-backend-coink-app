using Application.Commons;
using MediatR;

namespace Application.Users.Command.Create
{
    public class CreateUserCommand : IRequest<Result<CreateUserCommandResponse>>
    {
            public string Identification { get; set; }
            public string FullName { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CityId { get; set; }
            public string CityName { get; set; }

    }
}