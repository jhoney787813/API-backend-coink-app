using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Users.Query.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse?>
    {
        private readonly IGetUserByIdUseCase _getUserByIdUseCase;

        public GetUserByIdQueryHandler(IGetUserByIdUseCase getUserByIdUseCase)
        {
            _getUserByIdUseCase = getUserByIdUseCase;
        }

        public async Task<GetUserByIdQueryResponse?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _getUserByIdUseCase.Execute(request.Identification);
            return MapToResponse(result);
        }

        private GetUserByIdQueryResponse? MapToResponse(UserData User)
        {
            if (User is not null)
                return new GetUserByIdQueryResponse(User.Identification, User.FullName, User.Phone, User.Address, User.CityId,User.CityName);

            return default;
        }
    }
}

