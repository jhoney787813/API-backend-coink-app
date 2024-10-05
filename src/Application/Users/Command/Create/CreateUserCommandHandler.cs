using System.Text;
using System.Text.RegularExpressions;
using Application.Commons;
using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Users.Command.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<CreateUserCommandResponse>>
    {
        private readonly ICreateUserUseCase _createUserUseCase;

        public CreateUserCommandHandler(ICreateUserUseCase createUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
        }

        public async Task<Result<CreateUserCommandResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            StringBuilder errors;
            if (ModelIsValid(request, out errors))
            {
                var User = new User(request.Identification, request.FullName, request.Phone, request.Address, request.CityId);
                var result = await _createUserUseCase.Execute(User);
                return Result<CreateUserCommandResponse>.Success(MapToResponse(result));
            }

            return Result<CreateUserCommandResponse>.Failure(errors.ToString());
        }

        private bool ModelIsValid(CreateUserCommand createUserCommand, out StringBuilder errors)
        {
            errors = new StringBuilder();

            if (string.IsNullOrEmpty(createUserCommand.FullName))
                errors.Append("The full name must not be empty.\n");
            else if (createUserCommand.FullName.Length > 100)
                errors.Append("The full name cannot exceed 100 characters.\n");

            if (string.IsNullOrEmpty(createUserCommand.Identification))
                errors.Append("Identification must not be empty.\n");
            else if (createUserCommand.Identification.Length > 12)
                errors.Append("Identification cannot exceed 12 characters.\n");

            if (!string.IsNullOrEmpty(createUserCommand.Phone) && createUserCommand.Phone.Length > 15)
                errors.Append("The phone cannot exceed 15 characters.\n");

            if (!string.IsNullOrEmpty(createUserCommand.Address) && createUserCommand.Address.Length > 255)
                errors.Append("The address cannot exceed 255 characters.\n");

            if (createUserCommand.CityId <= 0)
                errors.Append("CityId must be a valid number greater than zero.\n");

            return errors.Length == 0;
        }

        private CreateUserCommandResponse MapToResponse(User User)
        {
            return new CreateUserCommandResponse(User.Identification, User.FullName, User.Phone, User.Address, User.CityId);
        }
    }
}