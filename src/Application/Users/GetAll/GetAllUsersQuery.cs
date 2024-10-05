using MediatR;

namespace Application.Users.GetAll
{
	public class GetAllUsersQuery : IRequest<IEnumerable<GetAllUsersQueryResponse>>
    {
	}
}