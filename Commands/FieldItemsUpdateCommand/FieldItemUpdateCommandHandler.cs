using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;

namespace WebsiteManagerPanel.Commands.FieldItemsUpdateCommand
{
    public class FieldItemUpdateCommandHandler : IRequestHandler<FieldItemUpdateCommand, int>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public FieldItemUpdateCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(FieldItemUpdateCommand request, CancellationToken cancellationToken)
        {
            var site = await _repository.Include(p => p.Definitions).ThenInclude(p => p.Fields).ThenInclude(p => p.FieldValues).ThenInclude(p=>p.Items).FirstOrDefaultAsync(p => p.Id == request.SiteId);
            Argument.CheckIfNull(site, "site");
            var defintion = site.Definitions.FirstOrDefault(p => p.Id == request.DefinitionId&&p.IsActive);
            Argument.CheckIfNull(defintion, "defintion");
            var field = defintion.Fields.FirstOrDefault(p => p.Id == request.FieldId && p.IsActive);
            Argument.CheckIfNull(field, "field");
            var fieldValue = field.FieldValues.FirstOrDefault(p=>p.Id==request.FieldValueId && p.IsActive);
            Argument.CheckIfNull(fieldValue, "fieldValue");
            var fieldItem = fieldValue.Items.FirstOrDefault(p=>p.Id==request.FieldItemId && p.IsActive);
            Argument.CheckIfNull(fieldItem, "fieldItem");
            fieldItem.Update(request.FieldItemValue);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return field.Id;
        }
    }
}
