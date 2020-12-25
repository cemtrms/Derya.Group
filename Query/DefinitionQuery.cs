using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Data.Entities.Enums;
using WebsiteManagerPanel.Models;

namespace WebsiteManagerPanel.Query
{
    public class DefinitionQuery : BaseQuery<Definition>
    {
        public DefinitionQuery(DbContext dbContext) : base(dbContext)
        {
        }


        public async Task<List<DefinitionsViewModel>> GetAllAsync()
        {
            var definition = await Query.Include(P => P.CreateUser).Include(p => p.ModifyUser).Include(p=>p.Site).ToListAsync();
            var list = definition.Select(p => new DefinitionsViewModel
            {
                Id = p.Id,
                DefinitionName = p.Name,
                SiteId = p.Site.Id,
                SiteName = p.Site.Name,
                CreatedName = p.CreateUser.FirstName + " " + p.CreateUser.LastName,
                CreateDate = p.CreateDate,
                ModifiedName = p.ModifyUser?.FirstName + " " + p.ModifyUser?.LastName,
                ModifyDate = p?.ModifyDate,
                IsActive = p.IsActive,
            }).ToList();
            return list;
        }

        public async Task<DefinitionDetailViewModel> GetByIdAsync(int id)
        {
            var definition = await Query.Include(P => P.CreateUser).Include(p => p.ModifyUser)
                .Include(p => p.Fields).ThenInclude(p => p.CreateUser)
                .Include(p => p.Fields)
                .ThenInclude(p => p.ModifyUser)
                .Include(p=>p.Site)
                .FirstOrDefaultAsync(p => p.Id == id);
            var result = new DefinitionDetailViewModel
            {
                DefinitionId = definition.Id,
                DefinitionName = definition.Name,
                CreatedName = definition.CreateUser.FirstName + " " + definition.CreateUser.LastName,
                CreateDate = definition.CreateDate,
                ModifiedName = definition.ModifyUser?.FirstName + " " + definition.ModifyUser?.LastName,
                ModifyDate = definition.ModifyDate,
                Description= definition.Description,
                IsActive= definition.IsActive,
                SiteId=definition.Site.Id,
                SiteName=definition.Site.Name,
                Fields = definition.Fields.Select(b => new FieldViewModel
                {
                    Id = b.Id,
                    IsActive = b.IsActive,
                    Description = b.Description,
                    FieldName = b.Name,
                    FielType=b.Type.ToString(),
                    CreatedName = b.CreateUser.FirstName + " " + b.CreateUser.LastName,
                    CreateDate = b.CreateDate,
                    ModifiedName = b.ModifyUser?.FirstName + " " + b.ModifyUser?.LastName,
                    ModifyDate = b.ModifyDate,
                }).ToList()
            };
            return result;
        }

       

        public async Task<bool> CheckAllreadyExistDefinitionNameAync(int siteId, string name)
        {
            return await Query.Include(p => p.Site).AnyAsync(p => p.Site.Id == siteId && p.Name==name);
        }
        public async Task<bool> CheckAllreadyExistotherThanThisDefinitionAync(Definition definition, string name)
        {
            var any = await Query.Where(p => p.Name == name && p.Id != definition.Id).ToListAsync();
            foreach (var item in any)
            {
                if (item.Name == name) return true;
            }
            return false;
        }
      

        public async Task<DefinitionUpdateViewModel> GetDefinition(int id)
        {
            var def = await Query.Include(p=>p.Site).FirstOrDefaultAsync(p=>p.Id==id);
            return new DefinitionUpdateViewModel {Id=def.Id,Name=def.Name,Description=def.Description,SiteName = def.Site.Name, SiteId = def.Site.Id };
        }

        public async Task<FieldInsertViewModel> GetFieldForInsert(int definitionId)
        {
            var def = await Query.Include(p => p.Site).FirstOrDefaultAsync(p => p.Id == definitionId);
            var data = new FieldInsertViewModel { DefinitionId = def.Id, SiteId = def.Site.Id, SiteName = def.Site.Name, DefinitionName = def.Name };
            data.FieldTypes = ((FieldType[])Enum.GetValues(typeof(FieldType))).Select(c => new SelectListItem { Value = ((byte)c).ToString(), Text = c.ToString() }).ToList();
            return data;
        }
    }
}
