﻿using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.ApplicationUser.Commands.RequestModels
{
    public class SoftDeleteAndActivateUserCommandRequestQuery : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
