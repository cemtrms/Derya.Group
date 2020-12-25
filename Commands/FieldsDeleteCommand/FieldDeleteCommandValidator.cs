using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.FieldsDeleteCommand
{
    public class FieldDeleteCommandValidator : AbstractValidator<FieldDeleteCommand>
    {
        public FieldDeleteCommandValidator()
        {
            RuleFor(p=>p.Id).NotNull().WithMessage("Alan bilgisi boş bırakılamaz");
            RuleFor(p => p.DefinitionId).NotNull().WithMessage("Tanım bilgisi boş bırakılamaz");
            RuleFor(p => p.SiteId).NotNull().WithMessage("Site bilgisi boş bırakılamaz");
        }
    }
}
