using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Models
{
    public class FieldsViewModel
    {
        public int Id { get; set; }
        public int DefinitionId { get; set; }
        public int SiteId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string CreatedName { get; set; }
        public DateTime CreateDate { get; set; }
        public string ? ModifiedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string DefinitionName { get; set; }
        public string SiteName { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
