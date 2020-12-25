using FluentValidation;

namespace WebsiteManagerPanel.Commands.FieldsInsertCommand
{
    public class FieldInsertCommandValidator : AbstractValidator<FieldInsertCommand>
    {
        public FieldInsertCommandValidator()
        {
            RuleFor(p=>p.Name).NotNull().WithMessage("Alan adı boş bırakılamaz");
            RuleFor(p => p.SiteId).NotNull().WithMessage("Site adı boş bırakılamaz");
            RuleFor(p => p.DefinitionId).NotNull().WithMessage("Tanım adı boş bırakılamaz");
            RuleFor(p => p.FieldType).NotNull().WithMessage("Tip bilgisi boş bırakılamaz");
        }
    }
}
