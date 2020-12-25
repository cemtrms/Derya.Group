using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Models
{
    public class DefinitionDetailViewModel
    {
        public int DefinitionId { get; set; }
        public string DefinitionName { get; set; }

        public string CreatedName { get; set; }
        public DateTime CreateDate { get; set; }

        public string? ModifiedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string SiteName { get; set; }
        public List<FieldViewModel> Fields { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public int SiteId { get; set; }
    }
    public class FieldViewModel
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string FielType { get; set; }
        public string Description { get; set; }
        public string CreatedName { get; set; }
        public DateTime CreateDate { get; set; }
        public string? ModifiedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool IsActive { get; set; }
    }
}
