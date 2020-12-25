using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.UsersInsertCommand
{
    public class UserInsertCommandValidator : AbstractValidator<UserInsertCommand>
    {
        public UserInsertCommandValidator()
        {
            RuleFor(p=>p.Email).NotNull().WithMessage("Kullanıcı mail bilgisi boş bırakılamaz");
            RuleFor(p => p.Password).NotNull().WithMessage("Kullanıcı şifre bilgisi boş bırakılamaz");
        }
    }
}
