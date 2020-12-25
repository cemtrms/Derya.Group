using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.SitesDeleteCommand
{
    public class SiteDeleteCommandValidator : AbstractValidator<SiteDeleteCommand>
    {
        public SiteDeleteCommandValidator()
        {
            RuleFor(p=>p.Id).NotNull().WithMessage("Site bilgisi boş bırakılamaz");
        }
    }
}
