﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.DefinitionsUpdateCommand
{
    public class DefinitionUpdateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
