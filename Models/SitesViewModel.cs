using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Models
{
    public class SitesViewModel
    {
        public int Id { get; set; }
        public string CreatedName { get; set; }
        public DateTime CreateDate { get; set; }
        public string ? ModifiedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string SiteName { get; set; }
        public bool IsActive { get; set; }
    }
}
