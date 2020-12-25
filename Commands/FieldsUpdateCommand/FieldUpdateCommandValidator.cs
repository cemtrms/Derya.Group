using FluentValidation;

namespace WebsiteManagerPanel.Commands.FieldsUpdateCommand
{
    public class FieldUpdateCommandValidator : AbstractValidator<FieldUpdateCommand>
    {
        public FieldUpdateCommandValidator()
        {
            RuleFor(p=>p.Name).NotNull().WithMessage("Alan adı boş bırakılamaz");
            RuleFor(p => p.Id).NotNull().WithMessage("Alan bilgisi adı boş bırakılamaz");
            RuleFor(p => p.SiteId).NotNull().WithMessage("Site adı boş bırakılamaz");
            RuleFor(p => p.DefinitionId).NotNull().WithMessage("Tanım adı boş bırakılamaz");
        }
    }
}
