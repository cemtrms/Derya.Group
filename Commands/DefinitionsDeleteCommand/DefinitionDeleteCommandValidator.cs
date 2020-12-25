using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.DefinitionsDeleteCommand
{
    public class DefinitionDeleteCommandValidator : AbstractValidator<DefinitionDeleteCommand>
    {
        public DefinitionDeleteCommandValidator()
        {
            RuleFor(p=>p.Id).NotNull().WithMessage("Tanım bilgisi boş bırakılamaz");
            RuleFor(p => p.SiteId).NotNull().WithMessage("Site bilgisi boş bırakılamaz");
        }
    }
}
