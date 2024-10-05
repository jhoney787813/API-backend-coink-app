﻿using Application.Commons;
using MediatR;

namespace Application.Users.GetById
{
	public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponse?>
	{
        public GetUserByIdQuery(string identification)
        {
            Identification = identification;
        }

        public string Identification { get; set; }
	}
}