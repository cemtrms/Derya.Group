using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Commands.SitesUpdateCommand;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Models;

namespace WebsiteManagerPanel.Query
{
    public class SiteQuery : BaseQuery<Site>
    {
        public SiteQuery(DbContext dbContext) : base(dbContext)
        {
        }


        public async Task<List<SitesViewModel>> GetAllAsync()
        {
            var sites = await Query.Include(P => P.CreateUser).Include(p => p.ModifyUser).ToListAsync();
            var list = sites.Select(p => new SitesViewModel
            {
                SiteName = p.Name,
                Id = p.Id,
                CreatedName = p.CreateUser.FirstName + " " + p.CreateUser.LastName,
                CreateDate = p.CreateDate,
                ModifiedName = p.ModifyUser?.FirstName + " " + p.ModifyUser?.LastName,
                ModifyDate = p?.ModifyDate,
                IsActive = p.IsActive,
            }).ToList();
            return list;
        }

        public async Task<bool> CheckAllreadyExistotherThanThisSiteAync(Site site, string name)
        {
            var any = await Query.Where(p => p.Name == name && p.Id != site.Id).ToListAsync();
            foreach (var item in any)
            {
                if (item.Name == name) return true;
            }
            return false;
        }

        public async Task<bool> CheckAllreadyExistAync(string name)
        {
            bool any = await Query.AnyAsync(p => p.Name == name);
            return any;
        }

        public async Task<SiteDetailViewModel> GetByIdAsync(int id)
        {
            var site = await Query.Include(P => P.CreateUser).Include(p => p.ModifyUser)
                .Include(p => p.Definitions).ThenInclude(p => p.CreateUser)
                .Include(p => p.Definitions)
                .ThenInclude(p => p.ModifyUser).FirstOrDefaultAsync(p => p.Id == id);

            var result = new SiteDetailViewModel
            {
                Id = site.Id,
                SiteName = site.Name,
                CreatedName = site.CreateUser.FirstName + " " + site.CreateUser.LastName,
                CreateDate = site.CreateDate,
                ModifiedName = site.ModifyUser?.FirstName + " " + site.ModifyUser?.LastName,
                ModifyDate = site.ModifyDate,
                Description = site.Description,
                IsActive = site.IsActive,
                Definitions = site.Definitions.Select(b => new DefinitionViewModel
                {
                    Id = b.Id,
                    IsActive = b.IsActive,
                    Description = b.Description,
                    Name = b.Name,
                    CreatedName = b.CreateUser.FirstName + " " + b.CreateUser.LastName,
                    CreateDate = b.CreateDate,
                    ModifiedName = b.ModifyUser?.FirstName + " " + b.ModifyUser?.LastName,
                    ModifyDate = b.ModifyDate,
                }).ToList()
            };
            return result;
        }

        public async Task<DefinitionInsertViewModel> GetSiteName(int id)
        {
            var site = await Query.FindAsync(id);
            return new DefinitionInsertViewModel { SiteName = site.Name, SiteId = site.Id };
        }
        public async Task<SiteUpdateViewModel> GetSite(int id)
        {
            var site = await Query.FindAsync(id);
            return new SiteUpdateViewModel { Name = site.Name, Id = site.Id, Description = site.Description };
        }
    }
}
