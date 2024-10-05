using Application.Commons;
using MediatR;

namespace Application.Users.Create
{
	public class CreateUserCommand : IRequest<Result<CreateUserCommandResponse>>
	{
		public string Identification { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public DateTime BirthDate { get; set; }
	}
}