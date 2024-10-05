using Application.Commons;
using MediatR;

namespace Application.Users.Command.Delete
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(string identification)
        {
            Identification = identification;
        }

        public string Identification { get; set; }
    }
}

