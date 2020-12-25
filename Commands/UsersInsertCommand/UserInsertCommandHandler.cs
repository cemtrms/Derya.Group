using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Helpers;
using WebsiteManagerPanel.Framework.Interface;
using WebsiteManagerPanel.Query;

namespace WebsiteManagerPanel.Commands.UsersInsertCommand
{
    public class UserInsertCommandHandler : IRequestHandler<UserInsertCommand, int>
    {
        private readonly IRepository<User> _repository;
        private readonly UserQuery _userQuery;
        private readonly IUnitOfWork _unitOfWork;

        public UserInsertCommandHandler(UserQuery userQuery, IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userQuery = userQuery;
            _unitOfWork = unitOfWork;
        }
        public UserInsertCommandHandler()
        {

        }
        public async Task<int> Handle(UserInsertCommand request, CancellationToken cancellationToken)
        {
            await _userQuery.CheckEmailAsync(request.Email);

            byte[] passwordHash, passwordSalt;
            UserHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            var newUser = new User(request, passwordHash, passwordSalt);
            _repository.MarkForInsertion(newUser);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newUser.Id;
        }
    }
}
