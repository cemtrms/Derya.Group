using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.FieldItemsInsertCommand
{
    public class FieldDeleteCommandValidator : AbstractValidator<FieldItemInsertCommand>
    {
        public FieldDeleteCommandValidator()
        {
            RuleFor(p=>p.FieldId).NotNull().WithMessage("Alan bilgisi boş bırakılamaz");
            RuleFor(p => p.DefinitionId).NotNull().WithMessage("Tanım bilgisi boş bırakılamaz");
            RuleFor(p => p.SiteId).NotNull().WithMessage("Site bilgisi boş bırakılamaz");
        }
    }
}
