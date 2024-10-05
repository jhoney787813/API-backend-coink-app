using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Users.Query.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUsersQueryResponse>>
    {
        private readonly IGetAllUserUseCase _getAllUsersUseCase;

        public GetAllUsersQueryHandler(IGetAllUserUseCase getAllUsersUseCase)
        {
            _getAllUsersUseCase = getAllUsersUseCase;
        }

        public async Task<IEnumerable<GetAllUsersQueryResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _getAllUsersUseCase.Execute();
            var response = MapToResponse(result);
            return response;
        }

        private List<GetAllUsersQueryResponse> MapToResponse(IEnumerable<UserData> result)
        {
            List<GetAllUsersQueryResponse> response = new();
            if(result.Count()>0) { 
            foreach (var item in result)
                response.Add(CreateUserRow(item));
            }
            return response;
            
        }

        private GetAllUsersQueryResponse CreateUserRow(UserData User)
        {
            return new GetAllUsersQueryResponse(User.Identification, User.FullName, User.Phone, User.Address, User.CityId,User.CityName);
        }
    }
}

