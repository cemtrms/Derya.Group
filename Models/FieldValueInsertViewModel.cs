using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Enums;

namespace WebsiteManagerPanel.Models
{
    public class FieldItemInsertViewModel
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public int DefinitionId { get; set; }
        public string DefinitionName { get; set; }
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public List<object> Values { get; set; }
        public FieldType FieldType { get; set; }
        public string FieldDescription { get; set; }
    }
}
