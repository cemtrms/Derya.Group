using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.SitesUpdateCommand
{
    public class SiteUpdateCommandValidator:AbstractValidator<SiteUpdateCommand>
    {
        public SiteUpdateCommandValidator()
        {
            RuleFor(p=>p.Name).NotNull().WithMessage("Site ismi boş bırakılamaz");
            RuleFor(p=>p.Id).NotNull().WithMessage("Site bilgisi boş bırakılamaz");
        }
    }
}
