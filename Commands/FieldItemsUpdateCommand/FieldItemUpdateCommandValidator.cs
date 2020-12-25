using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.FieldItemsUpdateCommand
{
    public class FieldItemUpdateCommandValidator : AbstractValidator<FieldItemUpdateCommand>
    {
        public FieldItemUpdateCommandValidator()
        {
            RuleFor(p=>p.FieldId).NotNull().WithMessage("Alan bilgisi boş bırakılamaz");
            RuleFor(p => p.DefinitionId).NotNull().WithMessage("Tanım bilgisi boş bırakılamaz");
            RuleFor(p => p.SiteId).NotNull().WithMessage("Site bilgisi boş bırakılamaz");
            RuleFor(p => p.FieldItemId).NotNull().WithMessage("Değer bilgisi boş bırakılamaz");
            RuleFor(p => p.FieldValueId).NotNull().WithMessage("Değer bilgisi boş bırakılamaz");

        }
    }
}
