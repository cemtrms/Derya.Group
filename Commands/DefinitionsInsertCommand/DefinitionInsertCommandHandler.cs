using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;
using WebsiteManagerPanel.Query;

namespace WebsiteManagerPanel.Commands.DefinitionsInsertCommand
{
    public class DefinitionInsertCommandHandler : IRequestHandler<DefinitionInsertCommand, int>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DefinitionQuery _definitionQuery;

        public DefinitionInsertCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork, DefinitionQuery definitionQuery)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _definitionQuery = definitionQuery;
        }
        public async Task<int> Handle(DefinitionInsertCommand request, CancellationToken cancellationToken)
        {
            bool isExist = await _definitionQuery.CheckAllreadyExistDefinitionNameAync(request.SiteId,request.Name);
            if (isExist) Argument.ThrowWorkflowException("Aynı isimde siteye aiy mevcutta bir tanım vardır,lütfen tanım adları farklı olacak şekilde düzenleme yapınız");
            var site =await _repository.Include(p=>p.Definitions).FirstOrDefaultAsync(p=>p.Id==request.SiteId);
            Argument.CheckIfNull(site, "site");
            site.AddDefinitions(request.Name,request.Description);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
           int recorId= site.Definitions.LastOrDefault().Id;
            return recorId;
        }
    }
}
