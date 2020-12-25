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
    public class FieldValueQuery : BaseQuery<FieldValue>
    {
        public FieldValueQuery(DbContext dbContext) : base(dbContext)
        {
        }
       

        public async Task<FieldItemAddViewModel> GetAllFielItemByIdAsync(int fieldValueId)
        {
            var fieldValue = await Query.Include(p => p.CreateUser).Include(p => p.ModifyUser)
                .Include(p => p.Items)
                .Include(p => p.Field).ThenInclude(p => p.Definition).ThenInclude(p => p.Site).FirstOrDefaultAsync(p => p.Id == fieldValueId&&p.IsActive);
            var result = new FieldItemAddViewModel
            {
                SiteId = fieldValue.Field.Definition.Site.Id,
                SiteName = fieldValue.Field.Definition.Site.Name,
                DefinitionId = fieldValue.Field.Definition.Id,
                DefinitionName = fieldValue.Field.Definition.Name,
                FieldId = fieldValue.Field.Id,
                FieldName = fieldValue.Field.Name,
                FieldType = fieldValue.Field.Type,
                FieldDescription = fieldValue.Field.Description,
                FieldValueId = fieldValue.Id,
                Items = fieldValue.Items.Select(p => new FieldItemViewModel
                {
                    FieldItemId = p.Id,
                    FieldItemValue = p.Value
                }).ToList()
            };
            return result;
        }

        
    }
}
