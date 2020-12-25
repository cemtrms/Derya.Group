using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Models
{
    public class DefinitionInsertViewModel
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
