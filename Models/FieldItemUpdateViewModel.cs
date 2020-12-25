using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Models
{
    public class FieldItemUpdateViewModel
    {
        public int FieldItemId { get; set; }
        public string FieldItemValue { get; set; }
        public string DefinitionName { get; set; }
        public int DefinitionId { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public int FieldValueId { get; set; }
    }
}
