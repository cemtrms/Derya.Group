using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;
using WebsiteManagerPanel.Query;

namespace WebsiteManagerPanel.Commands.FieldsUpdateCommand
{
    public class FieldUpdateCommandHandler : IRequestHandler<FieldUpdateCommand, int>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly FieldQuery _fieldQuery;

        public FieldUpdateCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork, FieldQuery fieldQuery)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
             _fieldQuery= fieldQuery;
        }
        public async Task<int> Handle(FieldUpdateCommand request, CancellationToken cancellationToken)
        {
            var site = await _repository.Include(p => p.Definitions).ThenInclude(p => p.Fields).FirstOrDefaultAsync(p => p.Id == request.SiteId);
            Argument.CheckIfNull(site, "site");
            var defintion = site.Definitions.FirstOrDefault(p => p.Id == request.DefinitionId);
            Argument.CheckIfNull(defintion, "defintion");
            var field = defintion.Fields.FirstOrDefault(p=>p.Id==request.Id);
            Argument.CheckIfNull(field, "field");
            bool isExist = await _fieldQuery.CheckAllreadyExistotherThanThisFieldAync(field,request.Name);
            if (isExist) Argument.ThrowWorkflowException("Aynı isimde  mevcutta bir field vardır,lütfen field adları farklı olacak şekilde düzenleme yapınız");
            field.Update(request.Name,request.Description);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}
