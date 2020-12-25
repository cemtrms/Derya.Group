using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;
using WebsiteManagerPanel.Query;

namespace WebsiteManagerPanel.Commands.SitesInsertCommand
{
    public class SiteInsertCommandHandler : IRequestHandler<SiteInsertCommand, int>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SiteQuery _siteQuery;

        public SiteInsertCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork, SiteQuery siteQuery)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _siteQuery = siteQuery;
        }
        public async Task<int> Handle(SiteInsertCommand request, CancellationToken cancellationToken)
        {
            bool isExist = await _siteQuery.CheckAllreadyExistAync(request.Name);
            if (isExist) Argument.ThrowWorkflowException("Aynı isimde mevcutta bir site vardır,lütfen site adları farklı olacak şekilde düzenleme yapınız");
            Site site = new Site(request.Name,request.Description);
            await _repository.MarkForInsertionAsync(site);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return site.Id;
        }
    }
}
