using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.DefinitionsInsertCommand
{
    public class DefinitionInsertCommand:IRequest<int>
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
