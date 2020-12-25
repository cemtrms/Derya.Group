using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Enums;

namespace WebsiteManagerPanel.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string CreatedName { get; set; }
        public DateTime CreateDate { get; set; }
        public string? ModifiedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string SiteName { get; set; }
        public int SiteId { get; set; }
        public string DefinitionName { get; set; }
        public int DefinitionId { get; set; }
        public string FieldName { get; set; }
        public int FieldId { get; set; }
        public int FieldValueId { get; set; }

        public bool IsActive { get; set; }
        public string Classification { get; set; }
        public FieldType FieldType { get; set; }

    }
}
