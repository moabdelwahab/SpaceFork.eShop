﻿using FluentValidation;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.Requests;

namespace SpaceFork.eShop.Ordering.Application.Features.Orders.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckOutOrderRequest>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(order => order.UserName).NotEmpty().WithMessage("The Username is Required");
            RuleFor(order => order.FirstName).NotEmpty().WithMessage("The FirstName is Required")
                .MaximumLength(50).WithMessage("First Name can't bet more than 10 charchters");
            RuleFor(order => order.EmailAddress).NotEmpty().WithMessage("The Emailis Required");

            RuleFor(order => order.TotalPrice).NotEmpty().WithMessage("The Total Price is Required")
                .GreaterThan(0).WithMessage("The value must be greater than zero");

        }
    }
}
