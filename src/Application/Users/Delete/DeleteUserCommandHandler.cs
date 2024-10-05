using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Users.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IDeleteUserUseCase _deleteCustomerUseCase;

        public DeleteUserCommandHandler(IDeleteUserUseCase deleteCustomerUseCase)
        {
            _deleteCustomerUseCase = deleteCustomerUseCase;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _deleteCustomerUseCase.Execute(request.Identification);
        }
    }
}