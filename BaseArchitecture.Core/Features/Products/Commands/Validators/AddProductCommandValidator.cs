using BaseArchitecture.Core.Features.Products.Commands.RequestModels;
using BaseArchitecture.Infrastructure.Shared.Localization;
using EcommerceProject.Service.ServiceInterfaces;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Core.Features.Products.Commands.Validators
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommandRequestModel>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IProductService _productService;
        #endregion

        #region Constructor
        public AddProductCommandValidator(IStringLocalizer<AppLocalization> stringLocalizer, IProductService productService)
        {
            _stringLocalizer = stringLocalizer;
            _productService = productService;
            ApplySignUpCommandValidation();
            ApplyCustomSignUpCommandValidation();
        }
        #endregion

        #region Methods

        public void ApplySignUpCommandValidation()
        {
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
            RuleFor(x => x.Stock)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
        }
        public void ApplyCustomSignUpCommandValidation()
        {
        }
        #endregion
    }

}
