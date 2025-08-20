using AutoMapper;
using BaseArchitecture.Core.Features.Products.Dto;
using BaseArchitecture.Core.Features.Products.Queries.RequestModels;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.PaginatedList;
using EcommerceProject.Service.ServiceInterfaces;
using MediatR;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Core.Features.Products.Queries.Handler
{
    public class ProductHandlerQuery : ResponseHandler,
                                    IRequestHandler<GetProductsListQueryRequestModel, Response<List<ProductFullDataDto>>>,
                                    IRequestHandler<GetProductByIdQueryRequestModel, Response<ProductFullDataDto>>,
                                    IRequestHandler<GetProductPaginatedListQueryRequestModel, Response<PaginatedList<ProductFullDataDto>>>
    {

        #region Fields
        private readonly IProductService _productService;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProductHandlerQuery(IProductService productService, IStringLocalizer<AppLocalization> stringLocalizer, IMapper mapper) : base(stringLocalizer)
        {
            _productService = productService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<Response<List<ProductFullDataDto>>> Handle(GetProductsListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var ProductList = await _productService.GetAll();
            if (ProductList == null)
                return NotFound<List<ProductFullDataDto>>(_stringLocalizer[AppLocalizationKeys.UserIsNotFound]);
            var ProductFullDataDtoList = _mapper.Map<List<ProductFullDataDto>>(ProductList);
            return Success(ProductFullDataDtoList, _stringLocalizer[AppLocalizationKeys.Success], new { TotalCount = ProductFullDataDtoList.Count });
        }

        public async Task<Response<ProductFullDataDto>> Handle(GetProductByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Product = await _productService.GetById(request.Id);
            if (Product == null)
                return NotFound<ProductFullDataDto>(_stringLocalizer[AppLocalizationKeys.UserIsNotFound]);
            var ProductFullDataDto = _mapper.Map<ProductFullDataDto>(Product);
            return Success(ProductFullDataDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<PaginatedList<ProductFullDataDto>>> Handle(GetProductPaginatedListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var PaginatedList = await _productService.GetPaginatedList(request.PageNumber, request.PageSize);
            if (PaginatedList == null || PaginatedList.Data.Count == 0)
                return NotFound<PaginatedList<ProductFullDataDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var ProductFullDataDtoList = _mapper.Map<List<ProductFullDataDto>>(PaginatedList.Data);
            var paginatedListDto = PaginatedList<ProductFullDataDto>.Success(ProductFullDataDtoList, PaginatedList.TotalCount, PaginatedList.CurrentPage, PaginatedList.PageSize);
            return Success(paginatedListDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }
        #endregion


    }
}
