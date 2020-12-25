using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;
using WebsiteManagerPanel.Query;

namespace WebsiteManagerPanel.Commands.DefinitionsUpdateCommand
{
    public class DefinitionUpdateCommandHandler : IRequestHandler<DefinitionUpdateCommand, int>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DefinitionQuery _definitionQuery;
        public DefinitionUpdateCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork, DefinitionQuery definitionQuery)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _definitionQuery = definitionQuery;
        }
        public async Task<int> Handle(DefinitionUpdateCommand request, CancellationToken cancellationToken)
        {
            var site = await _repository.Include(p => p.Definitions).FirstOrDefaultAsync(p => p.Id == request.SiteId);
            Argument.CheckIfNull(site, "site");
            var definition = site.Definitions.FirstOrDefault(p => p.Id == request.Id);
            Argument.CheckIfNull(definition, "defintion");
            bool isExist = await _definitionQuery.CheckAllreadyExistotherThanThisDefinitionAync(definition, request.Name);
            if (isExist) Argument.ThrowWorkflowException("Aynı isimde siteye ait mevcutta bir tanım vardır,lütfen tanım adları farklı olacak şekilde düzenleme yapınız");
            definition.Update(request.Name, request.Description);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}
