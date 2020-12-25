using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.DefinitionsInsertCommand
{
    public class DefinitionInsertCommandValidator : AbstractValidator<DefinitionInsertCommand>
    {
        public DefinitionInsertCommandValidator()
        {
            RuleFor(p=>p.Name).NotNull().WithMessage("Tanım bilgisi boş bırakılamaz");
            RuleFor(p => p.SiteId).NotNull().WithMessage("Site bilgisi boş bırakılamaz");

        }
    }
}
