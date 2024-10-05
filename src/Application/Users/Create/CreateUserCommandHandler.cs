using System.Text;
using System.Text.RegularExpressions;
using Application.Commons;
using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Users.Create
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<CreateUserCommandResponse>>
	{
        private readonly ICreateUserUseCase _createCustomerUseCase;

        public CreateUserCommandHandler(ICreateUserUseCase createCustomerUseCase)
        {
            _createCustomerUseCase = createCustomerUseCase;
        }

        public async Task<Result<CreateUserCommandResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            StringBuilder errors;
            if (ModelIsValid(request, out errors))
            {
                var customer = new Customer(request.Identification, request.FirstName, request.LastName, request.Email, request.BirthDate);
                var result = await _createCustomerUseCase.Execute(customer);
                return Result<CreateUserCommandResponse>.Success(MapToResponse(result));
            }

            return Result<CreateUserCommandResponse>.Failure(errors.ToString());
        }

        private bool ModelIsValid(CreateUserCommand CreateUserCommand, out StringBuilder errors)
        {
            errors = new StringBuilder();

            if (string.IsNullOrEmpty(CreateUserCommand.FirstName))
                errors.Append("First Name must not be empty.\n");

            if (string.IsNullOrEmpty(CreateUserCommand.LastName))
                errors.Append("Last Name must not be empty.\n");

            if (string.IsNullOrEmpty(CreateUserCommand.Identification))
                errors.Append("Identification must not be empty.\n");

            if (string.IsNullOrEmpty(CreateUserCommand.Email))
                errors.Append("Email must not be empty.\n");

            if (!Regex.IsMatch(CreateUserCommand.Email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
                errors.Append("Email is not in the correct format..\n");

            return errors.Length == 0;
        }

        private CreateUserCommandResponse MapToResponse(User customer)
        {
            return new CreateUserCommandResponse(customer.Identification, customer.FullName, customer.Phone, customer.Address, customer.BirthDate);
        }
    }
}