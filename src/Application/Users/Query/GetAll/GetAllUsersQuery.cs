using MediatR;

namespace Application.Users.Query.GetAll
{
    public class GetAllUsersQuery : IRequest<IEnumerable<GetAllUsersQueryResponse>>
    {
    }
}