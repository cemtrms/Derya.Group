using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;

namespace WebsiteManagerPanel.Commands.FieldItemsInsertCommand
{
    public class FieldItemInsertCommandHandler : IRequestHandler<FieldItemInsertCommand, int>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public FieldItemInsertCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(FieldItemInsertCommand request, CancellationToken cancellationToken)
        {
            var site = await _repository.Include(p => p.Definitions).ThenInclude(p => p.Fields).ThenInclude(p => p.FieldValues.Where(b=>b.IsActive)).FirstOrDefaultAsync(p => p.Id == request.SiteId);
            Argument.CheckIfNull(site, "site");
            var defintion = site.Definitions.FirstOrDefault(p => p.Id == request.DefinitionId);
            Argument.CheckIfNull(defintion, "defintion");
            var field = defintion.Fields.FirstOrDefault(p => p.Id == request.FieldId);
            Argument.CheckIfNull(field, "field");
            foreach (var value in request.Values)
            {
                field.FieldValues.Add(new FieldValue(value));
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return field.Id;
        }
    }
}
