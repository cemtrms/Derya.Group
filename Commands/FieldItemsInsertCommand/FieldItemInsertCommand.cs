using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Commands.FieldItemsInsertCommand
{
    public class FieldItemInsertCommand:IRequest<int>
    {
        public int SiteId { get; set; }
        public int DefinitionId { get; set; }
        public int FieldId { get; set; }
        public string[] Values { get; set; }
    }
}
