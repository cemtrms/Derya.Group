using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Base;
using WebsiteManagerPanel.Framework.Extensions;
using WebsiteManagerPanel.Framework.Interface;
using WebsiteManagerPanel.Models;

namespace WebsiteManagerPanel.Framework.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbDataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EfUnitOfWork(DbContext dbDataContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbDataContext = dbDataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Dispose()
        {
            _dbDataContext.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var numberRecord = 0;
            using (var transection = _dbDataContext.Database.BeginTransaction())
            {
                var changesets = _dbDataContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
                if (!changesets.Any(x => x.State != EntityState.Unchanged)) return 0;
                var changedSet = changesets.Where(x => x.State != EntityState.Unchanged);

                var modifiedEntries = changedSet
                    .Where(x => x.Entity.GetType().IsSubclassOfRawGeneric(typeof(AuditEntity<>)) && (x.State == EntityState.Added || x.State == EntityState.Modified));
               
                foreach (var entry in modifiedEntries)
                {
                    DateTime now = DateTime.Now;

                    var user= _httpContextAccessor.HttpContext.Session.GetObjectFromJson<SessionViewModel>("User"); 

                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreateDate").CurrentValue = now;
                        entry.Property("IsActive").CurrentValue = true;

                        //BugFix: EventBus üzerinde authorization bilgileri kullanılamaması kaynaklı hata için kontrol konulmuştur
                        if (user.Id.ToString().IsNotNullOrEmpty())
                            entry.Property("CreateUserId").CurrentValue = user.Id.ToInt32();
                        else entry.Property("CreateUserId").CurrentValue = 1; //Middleware yapısı kuruluncaya kadar geçici olarak işletilecektir.

                    }
                    else
                    {
                        entry.Property("ModifyDate").CurrentValue = now;

                        //BugFix: EventBus üzerinde authorization bilgileri kullanılamaması kaynaklı hata için kontrol konulmuştur
                        if (user.Id.ToString().IsNotNullOrEmpty())
                            entry.Property("ModifyUserId").CurrentValue = user.Id.ToInt32();
                    }
                }
              
                if (changesets.Any())
                {
                    try
                    {
                        numberRecord = await _dbDataContext.SaveChangesAsync(cancellationToken);
                        transection.Commit();
                    }
                    catch (Exception e)
                    {
                        transection.Rollback();
                        numberRecord = 0;
                    }
                }
            }
            return numberRecord;
        }
    }
}
