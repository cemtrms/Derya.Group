using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Enums;

namespace WebsiteManagerPanel.Models
{
    public class FieldItemAddViewModel
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public int DefinitionId { get; set; }
        public string DefinitionName { get; set; }
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public int FieldValueId { get; set; }
        public FieldType FieldType { get; set; }
        public string FieldDescription { get; set; }
        public List<FieldItemViewModel> Items { get; set; }
    }
    public class FieldItemViewModel
    {
        public int FieldItemId { get; set; }
        public string FieldItemValue { get; set; }
        public List<object> Values { get; set; }
    }

}
