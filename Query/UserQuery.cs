using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Framework.Exceptions;
using WebsiteManagerPanel.Framework.Helpers;
using WebsiteManagerPanel.Models;

namespace WebsiteManagerPanel.Query
{
    public class UserQuery : BaseQuery<User>
    {
        public UserQuery(DbContext dbContext) : base(dbContext)
        {

        }
        public async Task<User> GetById(int id)
        {
            var user = await Query.Include(p => p.UserRoles).ThenInclude(p => p.Roles).FirstOrDefaultAsync(p => p.Id == id);
            return user;
        }

        public async Task<SessionViewModel> LoginAsync(UserForLoginViewModel userForLoginDto)
        {
            var user = await Query.SingleOrDefaultAsync(u => u.Email == userForLoginDto.Email);
            Argument.CheckIfNull(user, "user");

            if (!UserHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                Argument.ThrowWorkflowException("Şifre bilgisi yanlıştır");
            }

            return new SessionViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<bool> CheckEmailAsync(string email)
        {
            var user = await Query.SingleOrDefaultAsync(u => u.Email == email);
            if (user != null) Argument.ThrowWorkflowException("Girmiş olduğunuz mail adresi sistemde kayıtlıdır");
            return true;
        }

    }
}
