using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.SitesInsertCommand
{
    public class SiteInsertCommandValidator:AbstractValidator<SiteInsertCommand>
    {
        public SiteInsertCommandValidator()
        {
            RuleFor(p=>p.Name).NotNull().WithMessage("Site bilgisi boş bırakılamaz");
        }
    }
}
