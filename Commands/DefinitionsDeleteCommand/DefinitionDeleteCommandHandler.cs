using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;

namespace WebsiteManagerPanel.Commands.DefinitionsDeleteCommand
{
    public class DefinitionDeleteCommandCommandHandler : IRequestHandler<DefinitionDeleteCommand, bool>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DefinitionDeleteCommandCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DefinitionDeleteCommand request, CancellationToken cancellationToken)
        {
            var site = await _repository.Include(p => p.Definitions).ThenInclude(P => P.Fields).FirstOrDefaultAsync(p => p.Id == request.SiteId);
            Argument.CheckIfNull(site, "site");
            var definition = site.Definitions.FirstOrDefault(p => p.Id == request.Id);
            Argument.CheckIfNull(definition, "definition");
            foreach (var field in definition.Fields)
            {
                foreach (var fieldValue in field.FieldValues)
                {
                    foreach (var item in fieldValue.Items)
                    {
                        item.Passive();
                    }
                    field.Passive();
                }
                field.Passive();
            }
            definition.Passive();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            int recorId = site.Definitions.LastOrDefault().Id;
            return true;
        }
    }
}
