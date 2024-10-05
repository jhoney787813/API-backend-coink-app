using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Users.GetAll
{
	public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUsersQueryResponse>>
	{
        private readonly IGetAllUserUseCase _getAllCustomersUseCase;

        public GetAllUsersQueryHandler(IGetAllUserUseCase getAllCustomersUseCase)
        {
            _getAllCustomersUseCase = getAllCustomersUseCase;
        }

        public async Task<IEnumerable<GetAllUsersQueryResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _getAllCustomersUseCase.Execute();
            
            var response = MapToResponse(result);
            
            return response;
        }

        private List<GetAllUsersQueryResponse> MapToResponse(IEnumerable<User> result)
        {
            List<GetAllUsersQueryResponse> response = new();
            foreach (var item in result)
                response.Add(CreateCustomerRow(item));

            return response;
        }

        private GetAllUsersQueryResponse CreateCustomerRow(User customer)
        {
            return new GetAllCustomersQueryResponse(customer.Identification, customer.FullName, customer.Phone, customer.Address, customer.BirthDate);
        }
    }
}

