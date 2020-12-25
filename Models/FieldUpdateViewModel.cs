using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Models
{
    public class FieldUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DefinitionName { get; set; }
        public int DefinitionId { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string Description { get; set; }

    }
}
