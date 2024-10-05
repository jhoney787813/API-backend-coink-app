using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Users.GetById
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

        private GetUserByIdQueryResponse? MapToResponse(User User)
        {
            if (User is not null)
                return new GetUserByIdQueryResponse(User.Identification, User.FullName, User.Phone, User.Address, User.BirthDate);

            return default;
        }
    }
}

