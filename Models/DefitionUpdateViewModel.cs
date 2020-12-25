using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Models
{
    public class DefinitionUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
    }
}
