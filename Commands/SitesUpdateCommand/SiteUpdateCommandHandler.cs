using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Interface;
using WebsiteManagerPanel.Query;

namespace WebsiteManagerPanel.Commands.SitesUpdateCommand
{
    public class SiteUpdateCommandHandler : IRequestHandler<SiteUpdateCommand, int>
    {
        private readonly IRepository<Site> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SiteQuery _siteQuery;

        public SiteUpdateCommandHandler(IRepository<Site> repository, IUnitOfWork unitOfWork, SiteQuery siteQuery)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _siteQuery = siteQuery;
        }
        public async Task<int> Handle(SiteUpdateCommand request, CancellationToken cancellationToken)
        {
            Site site = await _repository.GetSingleAsync(request.Id);
            Argument.CheckIfNull(site, "site");
            bool isExist = false;
            isExist = await _siteQuery.CheckAllreadyExistotherThanThisSiteAync(site, request.Name);
            if (isExist) Argument.ThrowWorkflowException("Aynı isimde mevcutta bir site vardır,lütfen site adları farklı olacak şekilde düzenleme yapınız");
            site.UpdateInfo(request.Name, request.Description);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}
