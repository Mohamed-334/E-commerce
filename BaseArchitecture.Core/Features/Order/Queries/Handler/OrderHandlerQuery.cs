using AutoMapper;
using BaseArchitecture.Core.Features.Orders.Dto;
using BaseArchitecture.Core.Features.Orders.Queries.RequestModels;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.PaginatedList;
using EcommerceProject.Service.ServiceInterfaces;
using MediatR;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Core.Features.Orders.Queries.Handler
{
    public class OrderHandlerQuery : ResponseHandler,
                                    IRequestHandler<GetOrdersListQueryRequestModel, Response<List<OrderFullDataDto>>>,
                                    IRequestHandler<GetOrderByIdQueryRequestModel, Response<OrderFullDataDto>>,
                                    IRequestHandler<GetOrderPaginatedListQueryRequestModel, Response<PaginatedList<OrderFullDataDto>>>
    {

        #region Fields
        private readonly IOrderService _orderService;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public OrderHandlerQuery(IOrderService orderService, IStringLocalizer<AppLocalization> stringLocalizer, IMapper mapper) : base(stringLocalizer)
        {
            _orderService = orderService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<Response<List<OrderFullDataDto>>> Handle(GetOrdersListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var OrderList = await _orderService.GetAll();
            if (OrderList == null)
                return NotFound<List<OrderFullDataDto>>(_stringLocalizer[AppLocalizationKeys.UserIsNotFound]);
            var OrderFullDataDtoList = _mapper.Map<List<OrderFullDataDto>>(OrderList);
            return Success(OrderFullDataDtoList, _stringLocalizer[AppLocalizationKeys.Success], new { TotalCount = OrderFullDataDtoList.Count });
        }

        public async Task<Response<OrderFullDataDto>> Handle(GetOrderByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Order = await _orderService.GetById(request.Id);
            if (Order == null)
                return NotFound<OrderFullDataDto>(_stringLocalizer[AppLocalizationKeys.UserIsNotFound]);
            var OrderFullDataDto = _mapper.Map<OrderFullDataDto>(Order);
            return Success(OrderFullDataDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<PaginatedList<OrderFullDataDto>>> Handle(GetOrderPaginatedListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var PaginatedList = await _orderService.GetPaginatedList(request.PageNumber, request.PageSize);
            if (PaginatedList == null || PaginatedList.Data.Count == 0)
                return NotFound<PaginatedList<OrderFullDataDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var OrderFullDataDtoList = _mapper.Map<List<OrderFullDataDto>>(PaginatedList.Data);
            var paginatedListDto = PaginatedList<OrderFullDataDto>.Success(OrderFullDataDtoList, PaginatedList.TotalCount, PaginatedList.CurrentPage, PaginatedList.PageSize);
            return Success(paginatedListDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }
        #endregion


    }
}
