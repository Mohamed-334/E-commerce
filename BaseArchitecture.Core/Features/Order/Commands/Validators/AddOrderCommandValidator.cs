using BaseArchitecture.Core.Features.Orders.Commands.RequestModels;
using BaseArchitecture.Infrastructure.Shared.Localization;
using EcommerceProject.Service.ServiceInterfaces;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Core.Features.Orders.Commands.Validators
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommandRequestModel>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IOrderService _orderService;
        #endregion

        #region Constructor
        public AddOrderCommandValidator(IStringLocalizer<AppLocalization> stringLocalizer, IOrderService orderService)
        {
            _stringLocalizer = stringLocalizer;
            _orderService = orderService;
            ApplySignUpCommandValidation();
            ApplyCustomSignUpCommandValidation();
        }
        #endregion

        #region Methods

        public void ApplySignUpCommandValidation()
        {
            RuleFor(x => x.TotalPrice)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
        }
        public void ApplyCustomSignUpCommandValidation()
        {
        }
        #endregion
    }

}
