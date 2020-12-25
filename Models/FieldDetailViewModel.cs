using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Models
{
    public class FieldDetailViewModel
    {
        public int FieldId { get; set; }
        public int SiteId { get; set; }
        public int DefinitionId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string CreatedName { get; set; }
        public DateTime CreateDate { get; set; }
        public string? ModifiedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string SiteName { get; set; }
        public string DefinitionName { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public List<FieldValueViewModel> FieldValues { get; set; }
    }
    public class FieldValueViewModel
    {
        public int FieldValueId { get; set; }
        public List<ItemsViewModel> Items { get; set; }
    }
    public class ItemsViewModel 
    {
        public int FieldItemId { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public string CreatedName { get; set; }
        public DateTime CreateDate { get; set; }
        public string? ModifiedName { get; set; }
        public DateTime? ModifyDate { get; set; }
    } 

}
