using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;
using WebsiteManagerPanel.Query;

namespace WebsiteManagerPanel.Commands.FieldsInsertCommand
{
    public class FieldInsertCommandHandler : IRequestHandler<FieldInsertCommand, int>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly FieldQuery _fieldQuery;

        public FieldInsertCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork, FieldQuery fieldQuery)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
             _fieldQuery= fieldQuery;
        }
        public async Task<int> Handle(FieldInsertCommand request, CancellationToken cancellationToken)
        {
            bool isExist = await _fieldQuery.CheckAllreadyExistFieldNameAync(request.SiteId,request.Name);
            if (isExist) Argument.ThrowWorkflowException("Aynı isimde  mevcutta bir field vardır,lütfen field adları farklı olacak şekilde düzenleme yapınız");
            var site =await _repository.Include(p=>p.Definitions).ThenInclude(p=>p.Fields).FirstOrDefaultAsync(p=>p.Id==request.SiteId);
            Argument.CheckIfNull(site,"site");
            var defintion = site.Definitions.FirstOrDefault(p=>p.Id==request.DefinitionId);
            Argument.CheckIfNull(defintion,"defintion");
            defintion.AddField(request.Name,request.Description,request.FieldType);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
           int recorId= defintion.Fields.LastOrDefault().Id;
            return recorId;
        }
    }
}
