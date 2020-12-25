using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.SitesInsertCommand
{
    public class SiteInsertCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
