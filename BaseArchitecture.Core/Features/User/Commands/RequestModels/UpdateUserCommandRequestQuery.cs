﻿using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.ApplicationUser.Commands.RequestModels
{
    public class UpdateUserCommandRequestQuery : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? NationalNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
