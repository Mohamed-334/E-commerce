using AutoMapper;
using BaseArchitecture.Core.Features.Products.Commands.RequestModels;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using EcommerceProject.Service.ServiceInterfaces;
using MediatR;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Core.Features.Products.Commands.Handlers
{
    public class ProductHandlerCommand : ResponseHandler,
                                        IRequestHandler<AddProductCommandRequestModel, Response<string>>,
                                        IRequestHandler<UpdateProductCommandRequestModel, Response<string>>,
                                        IRequestHandler<DeleteProductCommandRequestModel, Response<string>>,
                                        IRequestHandler<SoftDeleteAndActivateProductCommandRequestQuery, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IProductService _productService;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        #endregion

        #region Constructor
        public ProductHandlerCommand(IStringLocalizer<AppLocalization> stringLocalizer, IMapper mapper, IAuthenticationService authenticationService, IProductService productService, IAuthenticatedUserService authenticatedUserService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _authenticationService = authenticationService;
            _productService = productService;
            _authenticatedUserService = authenticatedUserService;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(AddProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Product = _mapper.Map<Product>(request);
            var result = await _productService.AddAsync(Product);
            if (result == _stringLocalizer[AppLocalizationKeys.AddFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.AddFailed]);
            return Success("");
        }

        public async Task<Response<string>> Handle(UpdateProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Product = await _productService.GetById(request.Id);
            if (Product == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);

            var ProductMapper = _mapper.Map(request, Product);
            var result = await _productService.EditAsync(ProductMapper);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.UpdateFailed]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Product = await _productService.GetById(request.Id);
            if (Product == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _productService.HardDeleteAsync(Product);
            if (result == _stringLocalizer[AppLocalizationKeys.DeletedFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
        }
        public async Task<Response<string>> Handle(SoftDeleteAndActivateProductCommandRequestQuery request, CancellationToken cancellationToken)
        {
            var Product = await _productService.GetById(request.Id);
            if (Product == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            Product.IsDeleted = !(Product.IsDeleted);
            Product.DeletionDate = DateTime.UtcNow;
            Product.DeleterName = _authenticatedUserService.GetAuthenticatedUserName();
            var result = await _productService.EditAsync(Product);

            if (result == _stringLocalizer[AppLocalizationKeys.DeletedFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            if (Product.IsDeleted)
                return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Activated]);
        }
        #endregion
    }
}
