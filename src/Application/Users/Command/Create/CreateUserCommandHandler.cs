using System.Text;
using System.Text.RegularExpressions;
using Application.Commons;
using Domain.Entities;
using Domain.Interfaces.Repositories;
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
            var (isValid, errors) = await CityIsValid(request);  // Uso de Tuple para devolver los dos valores

            if (ModelIsValid(request, out errors))
            {
                var user = new User(request.Identification, request.FullName, request.Phone, request.Address, request.CityId, request.CityName);
                var result = await _createUserUseCase.Execute(user);

                if (isValid)
                    return Result<CreateUserCommandResponse>.Success(MapToResponse(result));
                else
                    return Result<CreateUserCommandResponse>.Failure(errors.ToString());
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


        private async Task<(bool isValid, StringBuilder errors)> CityIsValid(CreateUserCommand createUserCommand)
        {
            var errors = new StringBuilder();
           bool isExist= await _createUserUseCase.ValidateCountry(createUserCommand.CityName);
            if (!isExist)
            {
                errors.Append("CityName is invalid\n");
               return (false, errors);
                
            }

            return (isExist, errors); 
        }

        private CreateUserCommandResponse MapToResponse(User user)
        {
            return new CreateUserCommandResponse(user.Identification, user.FullName, user.Phone, user.Address, user.CityId, user.CityName);
        }
    }
}