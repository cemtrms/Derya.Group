using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;

namespace WebsiteManagerPanel.Commands.FieldsDeleteCommand
{
    public class FieldDeleteCommandHandler : IRequestHandler<FieldDeleteCommand, bool>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public FieldDeleteCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(FieldDeleteCommand request, CancellationToken cancellationToken)
        {
            var site = await _repository.Include(p => p.Definitions).ThenInclude(p => p.Fields).ThenInclude(p => p.FieldValues.Where(p=>p.IsActive)).FirstOrDefaultAsync(p => p.Id == request.SiteId);
            Argument.CheckIfNull(site, "site");
            var defintion = site.Definitions.FirstOrDefault(p => p.Id == request.DefinitionId);
            Argument.CheckIfNull(defintion, "defintion");
            var field = defintion.Fields.FirstOrDefault(p => p.Id == request.Id);
            Argument.CheckIfNull(field, "field");
            foreach (var fieldValue in field.FieldValues)
            {
                foreach (var item in fieldValue.Items)
                {
                    item.Passive();
                }
                fieldValue.Passive();
            }
            field.Passive();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
