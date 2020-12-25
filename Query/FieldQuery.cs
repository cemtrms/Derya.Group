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
    public class FieldQuery : BaseQuery<Field>
    {
        public FieldQuery(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<FieldsViewModel>> GetAllAsync()
        {
            var field = await Query.Include(P => P.CreateUser).Include(p => p.ModifyUser)
                .Include(p => p.Definition).ThenInclude(p => p.Site)
                .ToListAsync();
            var list = field.Select(p => new FieldsViewModel
            {
                Id = p.Id,
                FieldName = p.Name,
                DefinitionId = p.Definition.Id,
                DefinitionName = p.Definition.Name,
                SiteId = p.Definition.Site.Id,
                SiteName = p.Definition.Site.Name,
                Description = p.Description,
                CreatedName = p.CreateUser.FirstName + " " + p.CreateUser.LastName,
                CreateDate = p.CreateDate,
                ModifiedName = p.ModifyUser?.FirstName + " " + p.ModifyUser?.LastName,
                ModifyDate = p?.ModifyDate,
                IsActive = p.IsActive,
            }).ToList();
            return list;
        }

        public async Task<bool> CheckAllreadyExistFieldNameAync(int id, string name)
        {
            var fields = await Query.Include(P => P.Definition).Where(p => p.Definition.Id == id).ToListAsync();
            bool any = fields.Any(p => p.Name == name);
            return any;
        }

        public async Task<FieldItemInsertViewModel> GetFieldValueByFieldId(int fieldId)
        {
            var field = await Query.Include(p => p.Definition).ThenInclude(p => p.Site).FirstOrDefaultAsync(p => p.Id == fieldId);
            return new FieldItemInsertViewModel { DefinitionId = field.Definition.Id, DefinitionName = field.Definition.Name, SiteId = field.Definition.Site.Id, SiteName = field.Definition.Site.Name, FieldId = field.Id, FieldName = field.Name, FieldDescription = field.Description, FieldType = field.Type };
        }

        public async Task<bool> CheckAllreadyExistotherThanThisFieldAync(Field field, string name)
        {
            var any = await Query.Where(p => p.Name == name && p.Id != field.Id).ToListAsync();
            foreach (var item in any)
            {
                if (item.Name == name) return true;
            }
            return false;
        }
        public async Task<List<FieldsViewModel>> GetAllBySiteIdAsync()
        {
            var definition = await Query.Include(P => P.CreateUser).Include(p => p.ModifyUser).Include(p => p.Definition).ThenInclude(p => p.Site).ToListAsync();
            var list = definition.Select(p => new FieldsViewModel
            {
                Id = p.Id,
                FieldName = p.Name,
                FieldType = p.Type.ToString(),
                DefinitionName = p.Definition.Name,
                DefinitionId = p.Definition.Id,
                Description = p.Description,
                SiteId = p.Definition.Site.Id,
                SiteName = p.Definition.Site.Name,
                CreatedName = p.CreateUser.FirstName + " " + p.CreateUser.LastName,
                CreateDate = p.CreateDate,
                ModifiedName = p.ModifyUser?.FirstName + " " + p.ModifyUser?.LastName,
                ModifyDate = p?.ModifyDate,
                IsActive = p.IsActive,
            }).ToList();
            return list;
        }
        public async Task<FieldUpdateViewModel> GetField(int id)
        {
            var field = await Query.Include(p => p.Definition).ThenInclude(p => p.Site).FirstOrDefaultAsync(p => p.Id == id);
            return new FieldUpdateViewModel { Id = field.Id, Name = field.Name, Description = field.Description, SiteName = field.Definition.Site.Name, SiteId = field.Definition.Site.Id, DefinitionId = field.Definition.Id, DefinitionName = field.Definition.Name };
        }

        public async Task<FieldDetailViewModel> GetByIdAsync(int fieldId)
        {
            var field = await Query.Include(P => P.CreateUser).Include(p => p.ModifyUser)
                .Include(p => p.FieldValues.Where(p=>p.IsActive)).ThenInclude(p => p.Items)
                .Include(p => p.Definition).ThenInclude(p => p.Site)
                .Where(p => p.Id == fieldId && p.IsActive).FirstOrDefaultAsync(p => p.Id == fieldId);
            var result = new FieldDetailViewModel
            {
                FieldId = field.Id,
                FieldName = field.Name,
                FieldType = field.Type.ToString(),
                CreatedName = field.CreateUser.FirstName + " " + field.CreateUser.LastName,
                CreateDate = field.CreateDate,
                ModifiedName = field.ModifyUser?.FirstName + " " + field.ModifyUser?.LastName,
                ModifyDate = field.ModifyDate,
                Description = field.Description,
                IsActive = field.IsActive,
                DefinitionId = field.Definition.Id,
                DefinitionName = field.Definition.Name,
                SiteId = field.Definition.Site.Id,
                SiteName = field.Definition.Site.Name,
                FieldValues = field.FieldValues.Select(b => new FieldValueViewModel
                {
                    FieldValueId = b.Id,
                    Items = b.Items.Select(i => new ItemsViewModel
                    {
                        FieldItemId = i.Id,
                        Value = i.Value,
                        IsActive = i.IsActive,
                        CreatedName = i.CreateUser.FirstName + " " + i.CreateUser.LastName,
                        CreateDate = i.CreateDate,
                        ModifiedName = i.ModifyUser?.FirstName + " " + i.ModifyUser?.LastName,
                        ModifyDate = i.ModifyDate
                    }).Where(p=>p.IsActive).ToList()


                }).ToList()
            };
            return result;
        }

    }
}
