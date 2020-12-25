using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Base;
using WebsiteManagerPanel.Framework.Interfaces;

namespace WebsiteManagerPanel.Data.Entities
{
    public class Site:AuditEntity, IAggreegateRoot
    {
        public string Name { get; set; }
        public string ? Description { get; set; }
        public ICollection<Definition>? Definitions { get; protected set; }
        protected Site()
        {
            Definitions =new List<Definition>();
        }
        public Site(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AddDefinitions(string name, string description)
        {
            Definitions.Add(new Definition ( name,description));
        }

        public void UpdateInfo(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
