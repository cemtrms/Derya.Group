using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Models
{
    public class FieldItemIdDeleteViewModel
    {
        public int FieldItemId { get; set; }
        public string FieldName { get; set; }
        public int FieldValueId { get; set; }
        public int FieldId { get; set; }
        public int SiteId { get; set; }
        public int DefinitionId { get; set; }
    }
}
