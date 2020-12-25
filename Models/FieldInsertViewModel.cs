using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Enums;

namespace WebsiteManagerPanel.Models
{
    public class FieldInsertViewModel
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public int DefinitionId { get; set; }
        public string DefinitionName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FieldType FieldType { get; set; }
        public IEnumerable<SelectListItem> FieldTypes { get; set; }

    }
    public class SelectView
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
