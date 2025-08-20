using AutoMapper;
using BaseArchitecture.Core.Features.Orders.Commands.RequestModels;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using EcommerceProject.Core.Features.Order.Commands.RequestModels;
using EcommerceProject.Service.ServiceInterfaces;
using MediatR;
using Microsoft.Extensions.Localization;
using static BaseArchitecture.Domain.Enums.EnumExtensions;

namespace BaseArchitecture.Core.Features.Orders.Commands.Handlers
{
    public class OrderHandlerCommand : ResponseHandler,
                                        IRequestHandler<AddOrderCommandRequestModel, Response<string>>,
                                        IRequestHandler<UpdateOrderCommandRequestModel, Response<string>>,
                                        IRequestHandler<DeleteOrderCommandRequestModel, Response<string>>,
                                        IRequestHandler<SoftDeleteAndActivateOrderCommandRequestQuery, Response<string>>,
                                        IRequestHandler<UpdateOrderStatusCommandRequestModel, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IOrderService _orderService;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        #endregion

        #region Constructor
        public OrderHandlerCommand(IStringLocalizer<AppLocalization> stringLocalizer, IMapper mapper, IAuthenticationService authenticationService, IOrderService orderService, IAuthenticatedUserService authenticatedUserService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _authenticationService = authenticationService;
            _orderService = orderService;
            _authenticatedUserService = authenticatedUserService;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(AddOrderCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Order = _mapper.Map<Order>(request);
            var result = await _orderService.AddAsync(Order);
            if (result == _stringLocalizer[AppLocalizationKeys.AddFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.AddFailed]);
            return Success("");
        }

        public async Task<Response<string>> Handle(UpdateOrderCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Order = await _orderService.GetById(request.Id);
            if (Order == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);

            var OrderMapper = _mapper.Map(request, Order);
            var result = await _orderService.EditAsync(OrderMapper);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.UpdateFailed]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteOrderCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Order = await _orderService.GetById(request.Id);
            if (Order == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _orderService.HardDeleteAsync(Order);
            if (result == _stringLocalizer[AppLocalizationKeys.DeletedFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
        }
        public async Task<Response<string>> Handle(SoftDeleteAndActivateOrderCommandRequestQuery request, CancellationToken cancellationToken)
        {
            var Order = await _orderService.GetById(request.Id);
            if (Order == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            Order.IsDeleted = !(Order.IsDeleted);
            Order.DeletionDate = DateTime.UtcNow;
            Order.DeleterName = _authenticatedUserService.GetAuthenticatedUserName();
            var result = await _orderService.EditAsync(Order);

            if (result == _stringLocalizer[AppLocalizationKeys.DeletedFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            if (Order.IsDeleted)
                return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Activated]);
        }

        public async Task<Response<string>> Handle(UpdateOrderStatusCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Order = await _orderService.GetById(request.Id);
            if (Order == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);

            Order.StatusCode = request.StatusCode;
            Order.Status = ((OrderStatus)request.StatusCode).ToString();
            var OrderMapper = _mapper.Map(request, Order);
            var Stock = await _orderService.ChangeProductStockForOrder(request.Id);
            if (Stock == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.StockNotEnough]);

            var result = await _orderService.EditAsync(OrderMapper);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.UpdateFailed]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Updated]);
        }
        #endregion
    }
}
