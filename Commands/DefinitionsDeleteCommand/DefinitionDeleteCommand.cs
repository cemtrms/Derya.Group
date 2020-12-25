using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.DefinitionsDeleteCommand
{
    public class DefinitionDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
    }
}
