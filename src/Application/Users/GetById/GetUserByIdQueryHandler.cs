using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Users.GetById
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse?>
	{
        private readonly IGetUserByIdUseCase _getCustomerByIdUseCase;

        public GetUserByIdQueryHandler(IGetUserByIdUseCase getCustomerByIdUseCase)
        {
            _getCustomerByIdUseCase = getCustomerByIdUseCase;
        }

        public async Task<GetUserByIdQueryResponse?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _getCustomerByIdUseCase.Execute(request.Identification);
            return MapToResponse(result);
        }

        private GetUserByIdQueryResponse? MapToResponse(User customer)
        {
            if (customer is not null)
                return new GetCustomerByIdQueryResponse(customer.Identification, customer.FullName, customer.Phone, customer.Address, customer.BirthDate);

            return default;
        }
    }
}

