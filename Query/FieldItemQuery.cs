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
    public class FieldItemQuery : BaseQuery<FieldItem>
    {
        public FieldItemQuery(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<ItemViewModel>> GetAllAsync()
        {
            var fielItems = await Query
                .Include(P => P.CreateUser)
                .Include(p => p.ModifyUser)
                .Include(p => p.FieldValue).ThenInclude(p=>p.Field).ThenInclude(p => p.Definition).ThenInclude(p => p.Site).ToListAsync();
            var list = fielItems.Select(p => new ItemViewModel
            {
                Id = p.Id,
                Value = p.Value,
                SiteName = p.FieldValue.Field.Definition.Site.Name,
                SiteId = p.FieldValue.Field.Definition.Site.Id,
                DefinitionId = p.FieldValue.Field.Definition.Id,
                DefinitionName = p.FieldValue.Field.Definition.Name,
                FieldId = p.FieldValue.Field.Id,
                FieldName = p.FieldValue.Field.Name,
                FieldType = p.FieldValue.Field.Type,
                CreatedName = p.CreateUser.FirstName + " " +p.CreateUser.LastName,
                CreateDate = p.CreateDate,
                ModifiedName =p.ModifyUser?.FirstName + " " + p.ModifyUser?.LastName,
                ModifyDate = p?.ModifyDate,
                IsActive =p.IsActive,
                FieldValueId=p.FieldValue.Id
            }).ToList();
            return list;
        }

        public async Task<FieldItemUpdateViewModel> GetById(int id)
        {
            var fielItem = await Query
                .Include(P => P.CreateUser)
                .Include(p => p.ModifyUser)
                .Include(p => p.FieldValue).ThenInclude(p => p.Field).ThenInclude(p => p.Definition).ThenInclude(p => p.Site).FirstOrDefaultAsync(p=>p.Id==id);
            return new FieldItemUpdateViewModel { FieldItemId= fielItem .Id,FieldItemValue= fielItem.Value,FieldValueId= fielItem .FieldValue.Id,FieldId= fielItem.FieldValue.Field.Id,FieldName= fielItem.FieldValue.Field.Name,DefinitionId= fielItem .FieldValue.Field.Definition.Id,DefinitionName= fielItem .FieldValue.Field.Definition.Name,SiteId=fielItem.FieldValue.Field.Definition.Site.Id,SiteName=fielItem.FieldValue.Field.Definition.Site.Name};
        }
    }
}
