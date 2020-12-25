using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;

namespace WebsiteManagerPanel.Commands.SitesDeleteCommand
{
    public class SiteDeleteCommandHandler : IRequestHandler<SiteDeleteCommand, bool>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SiteDeleteCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(SiteDeleteCommand request, CancellationToken cancellationToken)
        {
            var site = await _repository.Include(p=>p.Definitions).ThenInclude(p=>p.Fields).FirstOrDefaultAsync(p=>p.Id==request.Id);
            Argument.CheckIfNull(site, "site");
            foreach (var definition in site.Definitions)
            {
                foreach (var field in definition.Fields)
                {
                    field.Passive();
                    foreach (var fieldValue in field.FieldValues)
                    {
                        foreach (var item in fieldValue.Items)
                        {
                            item.Passive();
                        }
                        fieldValue.Passive();
                    }
                }
                definition.Passive();
            }
            site.Passive();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
