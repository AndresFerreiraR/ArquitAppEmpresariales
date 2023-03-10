using FluentValidation;
using Pacagroup.Ecommerce.Application.DTO;
using System;

namespace Pacagroup.Ecommerce.Application.Validator
{
    public class UsersDtoValidator : AbstractValidator<UsersDto>
    {
        public UsersDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}
