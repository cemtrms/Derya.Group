using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.DefinitionsUpdateCommand
{
    public class DefinitionUpdateCommandValidator : AbstractValidator<DefinitionUpdateCommand>
    {
        public DefinitionUpdateCommandValidator()
        {
            RuleFor(p=>p.Name).NotNull().WithMessage("Tanım ismi boş bırakılamaz");
            RuleFor(p => p.Id).NotNull().WithMessage("Tanım bilgisi boş bırakılamaz");
            RuleFor(p => p.SiteId).NotNull().WithMessage("Site bilgisi boş bırakılamaz");

        }
    }
}
