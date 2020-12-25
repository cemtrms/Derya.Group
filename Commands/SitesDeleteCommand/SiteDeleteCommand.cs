using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.SitesDeleteCommand
{
    public class SiteDeleteCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
