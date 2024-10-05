using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Users.Command.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IDeleteUserUseCase _deleteUserUseCase;

        public DeleteUserCommandHandler(IDeleteUserUseCase deleteUserUseCase)
        {
            _deleteUserUseCase = deleteUserUseCase;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _deleteUserUseCase.Execute(request.Identification);
        }
    }
}